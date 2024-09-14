import React from "react";
import axios from "axios";
import { Button, Form, Input, Card, Radio } from "antd";
import Swal from "sweetalert2";
import { useNavigate } from "react-router-dom";

const onFinishFailed = (errorInfo) => {
  console.log("Failed:", errorInfo);
};

function Register() {
  const navigate = useNavigate();

  const onFinish = async (values) => {
    try {
      // Make the API request to register the user, sending the selected role
      const register = await axios.post("http://localhost:5235/api/Users/Register", {
        UserName: values.username,
        Email: values.email,
        Password: values.password,
        Roles: [values.role],  // Send the selected role
      });

      Swal.fire({
        icon: "success",
        title: "Account Created",
        text: "You can now log in with your credentials.",
        color: "green",
        width: 400,
      });

      // Navigate to the login page after successful registration
      navigate("/login");
    } catch (e) {
      Swal.fire({
        icon: "error",
        title: "Registration Failed",
        text: "Please try again later.",
        color: "red",
        width: 400,
      });
    }
  };

  return (
    <div style={styles.container}>
      <Card
        style={{
          width: "30%",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <h1 style={styles.title}>Create Account</h1>

        <Form
          name="basic"
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
          autoComplete="off"
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
          }}
        >
          <Form.Item
            label="Username"
            name="username"
            rules={[
              {
                required: true,
                message: "Please input your username!",
              },
            ]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            label="Email"
            name="email"
            rules={[
              {
                required: true,
                message: "Please input your email!",
              },
            ]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            label="Password"
            name="password"
            rules={[
              {
                required: true,
                message: "Please input your password!",
              },
            ]}
          >
            <Input.Password />
          </Form.Item>

          <Form.Item
            label="Confirm Password"
            name="confirmPassword"
            dependencies={["password"]}
            rules={[
              {
                required: true,
                message: "Please confirm your password!",
              },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue("password") === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(new Error("Passwords do not match!"));
                },
              }),
            ]}
          >
            <Input.Password />
          </Form.Item>

          {/* Role selection */}
          <Form.Item
            label="Role"
            name="role"
            rules={[
              {
                required: true,
                message: "Please select a role!",
              },
            ]}
          >
            <Radio.Group>
              <Radio value="User">User</Radio>
              <Radio value="Admin">Admin</Radio>
            </Radio.Group>
          </Form.Item>

          <Form.Item style={{ alignSelf: "center" }}>
            <Button type="primary" htmlType="submit">
              Register
            </Button>
          </Form.Item>
        </Form>
      </Card>
    </div>
  );
}

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
  title: {
    textAlign: "center",
    marginBottom: "30px",
  },
};

export default Register;
