import React, { useEffect, useState } from 'react';
import { Button, Space, Table, Tag } from 'antd';
import axios from 'axios';
const { Column } = Table;


const AdminTaskList = () => {
    const [requests, setRequests] = useState();

    const getRequests = async () => {
        const account = JSON.parse(localStorage.getItem('account'));
        console.log('Token:', account.token);
        console.log('Role:', account.role);
        try {
            const request = await axios.get("http://localhost:5235/api/Employees/GetEmployeesRequests", {
                headers: { Authorization: `Bearer ${account.token}` },
            });

            console.log('requests', request);
            setRequests(request.data)


        } catch (e) {
            console.log(e);

        }
    }

    const updateStatus = async (requestId, newStatus) => {
        console.log(requestId, newStatus);

        const account = JSON.parse(localStorage.getItem('account'));
        try {
            await axios.put(`http://localhost:5235/api/Employees/UpdateRequestStatus/${requestId}`, `"${newStatus}"`, {
                headers: { Authorization: `Bearer ${account.token}`, 'Content-Type': 'application/json' },
            });


            getRequests();
        } catch (e) {
            console.log(e);
        }
    }



    useEffect(() => {
        getRequests()
    }, [])


    return (
        <div style={{ paddingTop: 20 }}>
            <Table dataSource={requests} bordered style={{ width: '90%', margin: '0 auto' }}>
                <Column title="Title" dataIndex="title" key="title" />
                <Column title="Description" dataIndex="description" key="description" />
                <Column title="Status" dataIndex="status" key="status" align='center' />
                <Column
                    title="Action"
                    key="action"
                    align='center'
                    render={(_, record) => (
                        <Space size="middle">
                            {record.status !== 'approved' ? (
                                <Button type="primary" onClick={() => updateStatus(record.id, 'approved')}>
                                    Approve
                                </Button>
                            ) : null}
                            {record.status !== 'declined' ? (
                                <Button type="primary" danger onClick={() => updateStatus(record.id, 'declined')}>
                                    Decline
                                </Button>
                            ) : null}
                        </Space>
                    )}
                />
            </Table>
        </div>

    );
}
export default AdminTaskList;