// Navbar.js
import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Layout, Menu, Avatar, Typography } from 'antd';
import {
  HomeOutlined,
  UserOutlined,
  LogoutOutlined,
  DashboardOutlined,
  QuestionCircleOutlined,
  AppstoreOutlined,
  SettingOutlined,
} from '@ant-design/icons';

const { Header } = Layout;
const { Title } = Typography;

function Navbar() {
  const [account, setAccount] = useState();
  const [role, setRole] = useState();
  const navigate = useNavigate();

  const logout = async () => {
    localStorage.clear();
    navigate('/login');
    window.location.reload();
  };

  useEffect(() => {
    const accountData = localStorage.getItem('account');
    setRole(localStorage.getItem('role'));
    setAccount(JSON.parse(accountData));
  }, []);

  const menuItems = [
    {
      key: 'home',
      icon: <HomeOutlined />,
      label: <Link to="/">Home</Link>,
    },
  ];

  if (role === 'Admin') {
    menuItems.push(
      {
        key: 'requests',
        icon: <AppstoreOutlined />,
        label: <Link to="/requests">Requests</Link>,
      },
      {
        key: 'stocks',
        icon: <SettingOutlined />,
        label: <Link to="/stocks">IT Stocks</Link>,
      },
      {
        key: 'jobs',
        icon: <AppstoreOutlined />,
        label: <Link to="/jobs">Jobs</Link>,
      }
    );
  }

  if (role === 'User') {
    menuItems.push(
      {
        key: 'dashboard',
        icon: <DashboardOutlined />,
        label: <Link to="/dashboard">Dashboard</Link>,
      },
      {
        key: 'faq',
        icon: <QuestionCircleOutlined />,
        label: <Link to="/faq">FAQ</Link>,
      }
    );
  }

  if (account) {
    menuItems.push(
      {
        key: 'logout',
        icon: <LogoutOutlined />,
        label: (
          <span onClick={logout} style={{ cursor: 'pointer' }}>
            Logout
          </span>
        ),
      },
      {
        key: 'account',
        icon: <Avatar icon={<UserOutlined />} />,
        label: (
          <span style={{ marginLeft: '8px' }}>
            Logged in as: <strong>{account.username}</strong>
          </span>
        ),
      }
    );
  } else {
    menuItems.push({
      key: 'login',
      icon: <UserOutlined />,
      label: <Link to="/login">Login</Link>,
    });
  }

  return (
    <Header style={{ backgroundColor: '#fff', padding: '0 20px' }}>
      <div
        className="logo"
        style={{
          float: 'left',
          marginRight: '20px',
          display: 'flex',
          alignItems: 'center',
          height: '100%',
        }}
      >
        <Title
          level={3}
          style={{
            margin: 0,
            color: '#1890ff',
            fontFamily: 'Roboto, sans-serif',
          }}
        >
          Employment Hub
        </Title>
      </div>
      <Menu
        theme="light"
        mode="horizontal"
        selectedKeys={[]}
        style={{ lineHeight: '64px' }}
        items={menuItems}
      />
    </Header>
  );
}

export default Navbar;
