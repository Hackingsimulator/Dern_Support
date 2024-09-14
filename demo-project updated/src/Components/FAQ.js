import React from 'react';
import { Collapse, Layout, Typography } from 'antd';

const { Panel } = Collapse;
const { Content } = Layout;
const { Title } = Typography;

const FAQ = () => {
  const faqData = [
    {
      question: "Why is my computer slow?",
      answer:
        "Your computer might be slow due to background processes, insufficient RAM, malware, or lack of disk space. Consider freeing up space, running a virus scan, or upgrading your hardware.",
    },
    {
      question: "How can I improve my computer's performance?",
      answer:
        "You can improve performance by clearing temporary files, uninstalling unnecessary programs, upgrading your RAM or SSD, and ensuring that your computer is free from viruses.",
    },
    {
      question: "Why is my internet connection so slow?",
      answer:
        "This can be caused by issues with your internet service provider, outdated hardware, too many devices connected, or interference from other networks. Restarting your router or contacting your ISP might help.",
    },
    {
      question: "Why does my computer keep crashing?",
      answer:
        "Frequent crashes may indicate software issues, outdated drivers, malware infections, or hardware malfunctions. Try updating your drivers, running a virus scan, or contacting a technician.",
    },
    {
      question: "How can I fix a printer that won't print?",
      answer:
        "Ensure that the printer is properly connected, check for paper jams, verify that you have the correct printer selected, and update or reinstall the printer driver if needed.",
    },
    {
      question: "Why is my computer overheating?",
      answer:
        "Overheating can be caused by dust blocking the fans, poor ventilation, or running intensive programs for extended periods. Clean the fans, use a cooling pad, and avoid using the laptop on soft surfaces.",
    },
    {
      question: "Why does my software freeze or become unresponsive?",
      answer:
        "Software may freeze due to bugs, insufficient resources, or conflicts with other applications. Try restarting the program, updating it, or reinstalling if the problem persists.",
    },
    {
      question: "Why can't I connect to Wi-Fi?",
      answer:
        "Check if the Wi-Fi is enabled on your device, restart your router, and ensure you're using the correct Wi-Fi credentials. It may also help to update your wireless adapter driver.",
    },
    {
      question: "What should I do if my screen is flickering?",
      answer:
        "Screen flickering can be caused by outdated drivers, incompatible apps, or a faulty display cable. Update your display drivers or change the refresh rate of your screen.",
    },
    {
      question: "How do I resolve a 'blue screen of death' error?",
      answer:
        "The blue screen typically indicates a critical system error. Check for hardware or software issues, update drivers, and run diagnostic tests. If the problem persists, consult a professional.",
    },
  ];

  return (
    <Layout style={{ padding: '20px' }}>
      <Content style={{ margin: '0 auto', maxWidth: '800px' }}>
        <Title level={2} style={{ textAlign: 'center' }}>Frequently Asked Questions (FAQ)</Title>
        <Collapse accordion>
          {faqData.map((faq, index) => (
            <Panel header={faq.question} key={index}>
              <p>{faq.answer}</p>
            </Panel>
          ))}
        </Collapse>
      </Content>
    </Layout>
  );
};

export default FAQ;
