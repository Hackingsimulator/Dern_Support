// ScheduleRepair.js
import React, { useState } from 'react';
import { Button, Modal, Form, Input, DatePicker, message } from 'antd';
import axios from 'axios';
import moment from 'moment';
import PropTypes from 'prop-types';

const ScheduleRepair = ({ fetchScheduledRepairs }) => {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [form] = Form.useForm();

  // Function to show the modal
  const showModal = () => {
    setIsModalVisible(true);
  };

  // Function to handle modal cancel
  const handleCancel = () => {
    setIsModalVisible(false);
    form.resetFields(); // Reset form fields when modal is closed
  };

  // Function to handle form submission and post to the backend
  const onFinish = async (values) => {
    try {
      console.log('Form Values:', values);

      const repairData = {
        Title: values.title,
        Description: values.description,
        RepairDate: values.repairDate.toISOString(),
      };

      console.log('Formatted Repair Data:', repairData);

      const account = JSON.parse(localStorage.getItem('account') || '{}');
      if (!account || !account.token) {
        message.error('Authorization token is missing. Please log in.');
        return;
      }

      console.log('Making API Request...');

      // Send POST request to backend
      const response = await axios.post(
        'http://localhost:5235/api/ScheduledRepairs/schedule',
        repairData,
        {
          headers: {
            Authorization: `Bearer ${account.token}`,
          },
        }
      );

      console.log('Backend Response:', response.data);
      message.success('Repair scheduled successfully!');
      setIsModalVisible(false);
      form.resetFields();

      // Refresh the appointments list
      if (fetchScheduledRepairs) {
        fetchScheduledRepairs();
      }
    } catch (error) {
      console.error('Error scheduling repair:', error);
      if (error.response && error.response.data) {
        console.error('Error Response Data:', error.response.data);
        message.error(`Failed to schedule repair: ${error.response.data}`);
      } else if (error.request) {
        console.error('Error Request:', error.request);
        message.error('No response received from the server.');
      } else {
        console.error('Error Message:', error.message);
        message.error(`Error: ${error.message}`);
      }
    }
  };

  return (
    <>
      <Button type="primary" onClick={showModal} style={{ marginTop: '10px' }}>
        Schedule Now
      </Button>

      {/* Modal for scheduling repair */}
      <Modal
        title="Schedule Repair Appointment"
        open={isModalVisible}
        onCancel={handleCancel}
        footer={null}
        destroyOnClose={true}
      >
        <Form
          form={form}
          layout="vertical"
          onFinish={onFinish}
          initialValues={{
            repairDate: moment(), // Default date to today
          }}
        >
          <Form.Item
            label="Title"
            name="title"
            rules={[{ required: true, message: 'Please input the title!' }]}
          >
            <Input placeholder="Enter the title" />
          </Form.Item>

          <Form.Item
            label="Description"
            name="description"
            rules={[{ required: true, message: 'Please input the description!' }]}
          >
            <Input.TextArea placeholder="Enter a brief description" />
          </Form.Item>

          <Form.Item
            label="Select Date and Time"
            name="repairDate"
            rules={[{ required: true, message: 'Please select date and time!' }]}
          >
            <DatePicker
              showTime
              format="YYYY-MM-DD HH:mm:ss"
              style={{ width: '100%' }}
            />
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit" block>
              Submit
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </>
  );
};

ScheduleRepair.propTypes = {
  fetchScheduledRepairs: PropTypes.func,
};

export default ScheduleRepair;
