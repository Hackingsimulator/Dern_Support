import "./App.css";
import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom"; 
import Login from "./Components/login";
import Register from "./Components/Register";  
import { useEffect, useState } from "react";
import Navbar from "./Components/Navbar";
import TaskForm from "./Components/TaskForm";
import AdminTaskList from "./Components/AdminTaskList";
import ITStock from "./Components/ITStock";
import Jobs from "./Components/Jobs";
import React from 'react';
import Dashboard from "./Components/Dashboard"; 
import FAQ from "./Components/FAQ";

function App() {
  const [isLoggedIn, setLoggedIn] = useState(false);
  const [role, setRole] = useState();

  useEffect(() => {
    const account = localStorage.getItem("account");
    const userRole = localStorage.getItem("role");
    
    setLoggedIn(!!account);  // Set to true if account exists
    setRole(userRole);
  }, []);

  return (
    <div>
      <Router>
        <Navbar />
        <Routes>
          {/* Public Route */}
          <Route
            path="/"
            element={
              <div
                style={{
                  backgroundImage:
                    "url(https://c0.wallpaperflare.com/preview/751/2/550/chart-graph-business-finance.jpg)",
                  backgroundSize: "cover",
                  backgroundPosition: "center",
                  backgroundRepeat: "no-repeat",
                  height: "91vh",
                }}
              ></div>
            }
          />
          
          {/* Registration Route */}
          <Route 
            path="/register" 
            element={isLoggedIn ? <Navigate to="/dashboard" /> : <Register />} 
          />

          {/* Login Route */}
          <Route 
            path="/login" 
            element={isLoggedIn ? <Navigate to="/dashboard" /> : <Login setLoggedIn={setLoggedIn} setRole={setRole} />} 
          />

          {/* Conditionally Render Routes Based on Login and Role */}
          {isLoggedIn ? (
            <>
              {/* User Routes */}
              {role === "User" ? (
                <>
                  <Route path="/dashboard" element={<Dashboard />} />
                  <Route path="/faq" element={<FAQ />} />
                </>
              ) : null}

              {/* Admin Routes */}
              {role === "Admin" ? (
                <>
                  <Route path="/requests" element={<AdminTaskList />} />
                  <Route path="/stocks" element={<ITStock />} />
                  <Route path="/jobs" element={<Jobs />} />
                </>
              ) : null}

              {/* Fallback route for logged-in users trying to access undefined routes */}
              <Route path="*" element={<Navigate to="/dashboard" />} />
            </>
          ) : (
            <>
              {/* Redirect to login if not logged in */}
              <Route path="*" element={<Navigate to="/login" />} />
            </>
          )}
        </Routes>
      </Router>
    </div>
  );
}

export default App;
