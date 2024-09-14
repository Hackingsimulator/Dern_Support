// Dashboard.js
import React, { useState, useEffect } from 'react';
import {
  Layout,
  Table,
  Card,
  Button,
  Row,
  Col,
  message,
  Typography,
  Badge,
} from 'antd';
import {
  CalendarOutlined,
  CustomerServiceOutlined,
} from '@ant-design/icons';
import ScheduleRepair from './ScheduleRepair';
import axios from 'axios';

const { Content, Footer } = Layout;
const { Title } = Typography;
const { Meta } = Card;

const Dashboard = () => {
  const [dataSource, setDataSource] = useState([]);

  // Function to fetch scheduled repairs
  const fetchScheduledRepairs = async () => {
    try {
      const account = JSON.parse(localStorage.getItem('account') || '{}');
      if (!account || !account.token) {
        message.error('Authorization token is missing. Please log in.');
        return;
      }

      const response = await axios.get(
        'http://localhost:5235/api/ScheduledRepairs/myrepairs',
        {
          headers: {
            Authorization: `Bearer ${account.token}`,
          },
        }
      );

      const repairs = response.data;

      // Map repairs to match table data format
      const formattedRepairs = repairs.map((repair) => ({
        key: repair.id,
        title: repair.title,
        description: repair.description,
        repairDate: new Date(repair.repairDate).toLocaleString(),
        status: repair.status,
      }));

      setDataSource(formattedRepairs);
    } catch (error) {
      console.error('Error fetching scheduled repairs:', error);
      message.error('Failed to fetch scheduled repairs.');
    }
  };

  // Fetch data when component mounts
  useEffect(() => {
    fetchScheduledRepairs();
  }, []);

  // Table columns
  const columns = [
    {
      title: 'Title',
      dataIndex: 'title',
      key: 'title',
      render: (text) => <strong>{text}</strong>,
    },
    {
      title: 'Description',
      dataIndex: 'description',
      key: 'description',
      ellipsis: true,
    },
    {
      title: 'Repair Date',
      dataIndex: 'repairDate',
      key: 'repairDate',
    },
    {
      title: 'Status',
      dataIndex: 'status',
      key: 'status',
      render: (status) => {
        let color = 'processing';
        if (status === 'Pending') {
          color = 'warning';
        } else if (status === 'In Progress') {
          color = 'processing';
        } else if (status === 'Completed') {
          color = 'success';
        }
        return <Badge status={color} text={status} />;
      },
    },
  ];

  return (
    <Layout style={{ minHeight: '100vh', backgroundColor: '#f0f2f5' }}>
      {/* Content */}
      <Content style={{ padding: '80px 50px 50px' }}>
        <div style={{ maxWidth: '1200px', margin: '0 auto' }}>
          <Title
            level={2}
            style={{
              textAlign: 'center',
              marginBottom: '40px',
              fontFamily: 'Roboto, sans-serif',
            }}
          >
            Welcome to Your Dashboard
          </Title>

          {/* Cards */}
          <Row gutter={[24, 24]} style={{ marginBottom: '40px' }}>
            <Col xs={24} sm={12} md={12}>
              <Card
                hoverable
                style={{ textAlign: 'center' }}
                cover={
                  <div
                    style={{
                      fontSize: '100px',
                      padding: '20px',
                      color: '#1890ff',
                    }}
                  >
                    <CalendarOutlined />
                  </div>
                }
              >
                <Meta
                  title="Schedule Repair Appointment"
                  description={
                    <ScheduleRepair fetchScheduledRepairs={fetchScheduledRepairs} />
                  }
                />
              </Card>
            </Col>
            <Col xs={24} sm={12} md={12}>
              <Card
                hoverable
                style={{ textAlign: 'center' }}
                cover={
                  <div
                    style={{
                      fontSize: '100px',
                      padding: '20px',
                      color: '#1890ff',
                    }}
                  >
                    <CustomerServiceOutlined />
                  </div>
                }
              >
                <Meta
                  title="Submit a Request"
                  description={
                    <Button type="primary" style={{ marginTop: '10px' }}>
                      Submit Now
                    </Button>
                  }
                />
              </Card>
            </Col>
          </Row>

          {/* Table */}
          <Title
            level={3}
            style={{
              marginBottom: '20px',
              fontFamily: 'Roboto, sans-serif',
            }}
          >
            Your Appointments
          </Title>
          <Table
            dataSource={dataSource}
            columns={columns}
            pagination={{ pageSize: 5 }}
            style={{ backgroundColor: '#fff', padding: '20px' }}
          />
        </div>
      </Content>

    </Layout>
  );
};

export default Dashboard;
