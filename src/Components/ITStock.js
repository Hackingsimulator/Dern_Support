import React, { useEffect, useState, useMemo } from "react";
import { Button, Form, Input, InputNumber, Modal, notification, Table } from "antd";
import axios from "axios";
import Swal from "sweetalert2";

const { Column } = Table;
const Context = React.createContext({
  name: "Default",
});

function ITStock() {
  const [stocks, setStocks] = useState();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false); // For adding new items
  const [editingStock, setEditingStock] = useState(null);

  const [api, contextHolder] = notification.useNotification();

  const openNotification = (placement) => {
    api.info({
      message: "Update Successful",
      description: <Context.Consumer>{({ name }) => `Stock ${editingStock.name} Updated`}</Context.Consumer>,
      placement,
    });
  };

  const contextValue = useMemo(() => ({ name: "Ant Design" }), []);

  const showModal = (record) => {
    setEditingStock(record);
    setIsModalOpen(true);
  };

  const handleCancel = () => {
    setIsModalOpen(false);
    setIsAddModalOpen(false); // Close the add modal too
  };

  const onFinishFailed = (errorInfo) => {
    handleCancel();
  };

  const getStocks = async () => {
    const account = JSON.parse(localStorage.getItem("account"));

    try {
      const response = await axios.get("http://localhost:5235/api/ITStocks/allStocks", {
        headers: { Authorization: `Bearer ${account.token}` },
      });

      setStocks(response.data);
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

  const onFormFinish = async (values) => {
    const account = JSON.parse(localStorage.getItem("account"));
    try {
      await axios.put(
        `http://localhost:5235/api/ITStocks/${editingStock.id}`,
        {
          quantityInStock: values.quantityInStock || editingStock.quantityInStock,
          description: values.description || editingStock.description,
          category: values.category || editingStock.category,
          name: values.name || editingStock.name,
        },
        {
          headers: {
            Authorization: `Bearer ${account.token}`,
            "Content-Type": "application/json",
          },
        }
      );

      getStocks();
      handleCancel();
      openNotification("bottomRight");
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

  const onAddFormFinish = async (values) => {
    const account = JSON.parse(localStorage.getItem("account"));
    try {
      await axios.post(
        `http://localhost:5235/api/ITStocks`,
        {
          name: values.name,
          category: values.category,
          description: values.description,
          quantityInStock: values.quantityInStock,
        },
        {
          headers: {
            Authorization: `Bearer ${account.token}`,
            "Content-Type": "application/json",
          },
        }
      );

      getStocks();
      handleCancel();
      Swal.fire({
        icon: "success",
        title: "Item Added",
        text: "New stock item added successfully!",
        color: "green",
        width: 400,
      });
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

  const onSearch = async (value) => {
    const account = JSON.parse(localStorage.getItem("account"));
    try {
      const response = await axios.get(`http://localhost:5235/api/ITStocks/search?name=${value}`, {
        headers: { Authorization: `Bearer ${account.token}` },
      });

      setStocks(response.data);
    } catch (e) {
      Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Item doesn't exist!",
        color: "red",
        width: 400,
      });
      getStocks();
    }
  };

  useEffect(() => {
    getStocks();
  }, []);

  return (
    <Context.Provider value={contextValue}>
      {contextHolder}

      <div style={{ padding: "20px 0", display: "flex", justifyContent: "center" }}>
        <Input.Search style={{ width: "33%" }} placeholder="Search" onChange={(e) => onSearch(e.target.value)} />
        <Button type="primary" style={{ marginLeft: "20px" }} onClick={() => setIsAddModalOpen(true)}>
          Add New Item
        </Button>
      </div>

      <div style={{ paddingTop: 20 }}>
        <Table dataSource={stocks} bordered style={{ width: "90%", margin: "0 auto" }}>
          <Column title="Name" dataIndex="name" key="name" />
          <Column title="Category" dataIndex="category" key="category" />
          <Column title="Description" dataIndex="description" key="description" />
          <Column
            title="Quantity In Stock"
            dataIndex="quantityInStock"
            key="quantityInStock"
            align="center"
            render={(quantityInStock) =>
              quantityInStock === 0 ? <span style={{ color: "red" }}>Out of Stock</span> : quantityInStock
            }
          />
          <Column
            title="Action"
            key="action"
            align="center"
            render={(_, record) => (
              <Button type="default" onClick={() => showModal(record)}>
                Edit
              </Button>
            )}
          />
        </Table>

        {/* Modal for editing existing stock */}
        <Modal title="Edit Stock" open={isModalOpen} onCancel={handleCancel} footer={null}>
          <Form layout="vertical" autoComplete="off" onFinish={onFormFinish} onFinishFailed={onFinishFailed}>
            <Form.Item label="Name" name="name">
              <Input defaultValue={editingStock?.name} disabled />
            </Form.Item>

            <Form.Item label="Category" name="category">
              <Input defaultValue={editingStock?.category} disabled />
            </Form.Item>

            <Form.Item label="Description" name="description">
              <Input.TextArea defaultValue={editingStock?.description} />
            </Form.Item>

            <Form.Item label="Quantity In Stock" name="quantityInStock">
              <InputNumber defaultValue={editingStock?.quantityInStock} />
            </Form.Item>

            <Form.Item>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Modal>

        {/* Modal for adding new stock */}
        <Modal title="Add New Stock" open={isAddModalOpen} onCancel={handleCancel} footer={null}>
          <Form layout="vertical" autoComplete="off" onFinish={onAddFormFinish} onFinishFailed={onFinishFailed}>
            <Form.Item label="Name" name="name" rules={[{ required: true, message: "Please enter the item name" }]}>
              <Input />
            </Form.Item>

            <Form.Item label="Category" name="category" rules={[{ required: true, message: "Please enter the category" }]}>
              <Input />
            </Form.Item>

            <Form.Item label="Description" name="description" rules={[{ required: true, message: "Please enter a description" }]}>
              <Input.TextArea />
            </Form.Item>

            <Form.Item label="Quantity In Stock" name="quantityInStock" rules={[{ required: true, message: "Please enter the quantity" }]}>
              <InputNumber />
            </Form.Item>

            <Form.Item>
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

export default ITStock;
