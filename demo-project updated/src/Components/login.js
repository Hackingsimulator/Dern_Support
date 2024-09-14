import React from "react";
import axios from "axios";
import { Button, Form, Input, Card } from "antd";
import { useNavigate } from "react-router-dom";
import { decodeToken } from "react-jwt";
import Swal from "sweetalert2";
import { Link } from "react-router-dom";

const Login = ({ setLoggedIn, setRole }) => {
  const navigate = useNavigate();

  const onFinish = async (values) => {
    try {
      // Send login request to the API
      const { data } = await axios.post("http://localhost:5235/api/Users/Login", {
        username: values.username,
        password: values.password,
      });

      // Decode the JWT token to retrieve user details
      const myDecodedToken = decodeToken(data.token);

      // Store user role and account details in local storage
      localStorage.setItem(
        "role",
        myDecodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      );
      localStorage.setItem("account", JSON.stringify(data));

      // Update the state to reflect the new login status
      setLoggedIn(true);
      setRole(myDecodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);

      // Redirect the user to the dashboard
      navigate("/dashboard");  // Redirect to dashboard upon successful login
    } catch (e) {
      Swal.fire({
        icon: "error",
        title: "Invalid Credentials",
        text: "Please check your username or password",
        color: "red",
        width: 400,
      });
    }
  };

  const onFinishFailed = (errorInfo) => {
    console.error("Failed:", errorInfo);
  };

  return (
    <div style={styles.container}>
      <Card style={styles.card}>
        <h1 style={styles.title}>Login</h1>

        <Form
          name="loginForm"
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
          autoComplete="off"
          layout="vertical"
          style={styles.form}
        >
          <Form.Item
            label="Username"
            name="username"
            rules={[{ required: true, message: "Please input your username!" }]}
          >
            <Input placeholder="Enter your username" />
          </Form.Item>

          <Form.Item
            label="Password"
            name="password"
            rules={[{ required: true, message: "Please input your password!" }]}
          >
            <Input.Password placeholder="Enter your password" />
          </Form.Item>

          <Form.Item style={{ textAlign: "center" }}>
            <Button type="primary" htmlType="submit" style={styles.submitButton}>
              Submit
            </Button>
            <div style={{ textAlign: "center", marginTop: "10px" }}>
                <span>Don't have an account? </span>
                <Link to="/register">Register here</Link>
            </div>
          </Form.Item>
        </Form>
      </Card>
    </div>
  );
};

const styles = {
  container: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    height: "100vh",
    justifyContent: "center",
    background:
      "radial-gradient(circle, rgba(163,163,163,1) 100%, rgba(230,230,230,1) 100%, rgba(168,191,197,1) 100%, rgba(32,25,56,1) 100%, rgba(0,255,239,1) 100%)",
  },
  card: {
    width: "30%",
    justifyContent: "center",
    alignItems: "center",
    padding: "20px",
    boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
    borderRadius: "8px",
  },
  title: {
    textAlign: "center",
    marginBottom: "30px",
    fontWeight: "bold",
    fontSize: "24px",
  },
  form: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
  },
  submitButton: {
    width: "100px",
  },
};

export default Login;
