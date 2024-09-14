import React, { useState } from "react";
import { Button, Form, Input, Modal } from "antd";
import axios from "axios";
import Swal from "sweetalert2";

function TaskForm() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const showModal = () => {
    setIsModalOpen(true);
  };

  const handleCancel = () => {
    setIsModalOpen(false);
  };

  const onFinishFailed = (errorInfo) => {
    handleCancel();
  };

  const onFinish = async (values) => {
    try {
      const account = JSON.parse(localStorage.getItem("account"));
      const response = await axios.post(
        "https://localhost:5235/api/Employees/SubmitRequest",
        {
          title: values.title,
          description: values.description,
          status: "pending",
        },
        {
          headers: { Authorization: `Bearer ${account.token}` },
        }
      );

      console.log(" submitted ", response.data);
      handleCancel();
    } catch (e) {
      handleCancel();
      Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
        color: "red",
        width: 400,
      });
    }
  };

  return (
    <div
      style={{
        display: "flex",
        height: "100vh",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column",
        gap: 10,
      }}
    >
      <h2>SUBMIT A REQUEST</h2>
      <Button
        style={{ width: 300 }}
        type="primary"
        size="large"
        onClick={showModal}
      >
        SHOW FORM
      </Button>
      <Modal title="SUBMIT A REQUEST" open={isModalOpen} footer={[<></>]}>
        <Form
          id="submitRequestForm"
          name="basic"
          layout="vertical"
          autoComplete="off"
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            marginTop: 30,
          }}
        >
          <Form.Item
            label="Title"
            name="title"
            rules={[
              {
                required: true,
                message: "Please input a title",
              },
            ]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            label="Description"
            name="description"
            rules={[
              {
                required: true,
                message: "Please input a Description",
              },
            ]}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item style={{ alignSelf: "center" }}>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
}

export default TaskForm;
