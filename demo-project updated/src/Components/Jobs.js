import React, { useEffect, useState, useMemo } from "react";
import {
  Button,
  DatePicker,
  Form,
  Input,
  InputNumber,
  Modal,
  notification,
  Table,
  Typography,
} from "antd";

import axios from "axios";
import Swal from "sweetalert2";

const Context = React.createContext({
  name: "Default",
});

const { Column } = Table;
const { Text } = Typography;

function Jobs() {
  const [jobs, setJobs] = useState();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [api, contextHolder] = notification.useNotification();

  const openNotification = (placement) => {
    api.info({
      message: "Schedule Successful",
      description: (
        <Context.Consumer>
          {({ name }) => `${isModalOpen.title} has been Scheduled`}
        </Context.Consumer>
      ),
      placement,
    });
  };
  const contextValue = useMemo(
    () => ({
      name: "Ant Design",
    }),
    []
  );

  const showModal = (job) => {
    setIsModalOpen(job);
  };

  const handleCancel = () => {
    setIsModalOpen(false);
  };

  const onFinishFailed = (errorInfo) => {
    handleCancel();
  };

  const getJobs = async () => {
    const account = JSON.parse(localStorage.getItem("account"));

    try {
      const response = await axios.get(
        "http://localhost:5235/api/Jobs/getAllJobs",
        {
          headers: { Authorization: `Bearer ${account.token}` },
        }
      );

      setJobs(response.data);
    } catch (e) {
      Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
        color: "red",
        width: 400,
      });
    }
  };

  const onFinish = async (values) => {
    const account = JSON.parse(localStorage.getItem("account"));
    try {
      await axios.put(
        `http://localhost:5235/api/Jobs/${isModalOpen.id}`,
        {
          title: isModalOpen.title,
          description: isModalOpen.description,
          location: isModalOpen.location,
          status: isModalOpen.status,
          priority: isModalOpen.priority,
          scheduledDate: values.scheduledDate,
        },
        {
          headers: {
            Authorization: `Bearer ${account.token}`,
            "Content-Type": "application/json",
          },
        }
      );

      getJobs();
      handleCancel();
      openNotification("bottomLeft");
    } catch (e) {
      Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
        color: "red",
        width: 400,
      });
    }
  };

  useEffect(() => {
    getJobs();
  }, []);

  return (
    <Context.Provider value={contextValue}>
      {contextHolder}

      <div style={{ paddingTop: 20 }}>
        <Table
          dataSource={jobs}
          bordered
          style={{ width: "90%", margin: "0 auto" }}
        >
          <Column title="Title" dataIndex="title" key="title" />
          <Column
            title="Description"
            dataIndex="description"
            key="description"
          />

          <Column
            title="Priority"
            dataIndex="priority"
            key="priority"
            align="center"
          />

          <Column
            title="Scheduled Date"
            dataIndex="scheduledDate"
            key="scheduledDate"
            render={(_, record) => {
              const date = new Date(record.scheduledDate);

              const formattedDate = date.toLocaleDateString("en-GB", {
                day: "2-digit",
                month: "long",
                year: "numeric",
              });

              return (
                <Text>
                  {record.scheduledDate ? formattedDate : "Not Scheduled"}
                </Text>
              );
            }}
          />
          <Column
            title="Action"
            key="action"
            align="center"
            render={(_, record) => (
              <Button type="default" onClick={() => showModal(record)}>
                Schedule
              </Button>
            )}
          />
        </Table>

        <Modal
          title="Schedule"
          open={isModalOpen}
          onCancel={handleCancel}
          footer={[<></>]}
        >
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
            <Form.Item label="Schedule Job" name="scheduledDate">
              <DatePicker />
            </Form.Item>

            <Form.Item style={{ alignSelf: "center" }}>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Modal>
      </div>
    </Context.Provider>
  );
}

export default Jobs;
