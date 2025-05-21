import React from 'react';
import { Container, Row, Col, Card, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLock, faSyncAlt, faDatabase } from '@fortawesome/free-solid-svg-icons';

const Home: React.FC = () => {
  return (
    <>
      {/* Hero Section */}
      <div className="bg-primary text-white py-5 mb-5">
        <Container>
          <Row className="align-items-center">
            <Col md={7}>
              <h1 className="display-4 fw-bold">Welcome to Mynewapp</h1>
              <p className="lead">
                A modern web application with real-time updates, secure authentication, and advanced features.
              </p>
              <Button as={Link as any} to="/register" variant="light" size="lg" className="me-2">
                Get Started
              </Button>
              <Button as={Link as any} to="/documentation" variant="outline-light" size="lg">
                Learn More
              </Button>
            </Col>
            <Col md={5} className="d-none d-md-block">
              <img 
                src="/dashboard-preview.png" 
                alt="Dashboard Preview" 
                className="img-fluid rounded shadow"
                style={{ maxHeight: '300px' }}
              />
            </Col>
          </Row>
        </Container>
      </div>

      {/* Features Section */}
      <Container className="mb-5">
        <h2 className="text-center mb-4">Key Features</h2>
        <Row>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body className="text-center">
                <FontAwesomeIcon icon={faLock} size="3x" className="text-primary mb-3" />
                <Card.Title>Secure Authentication</Card.Title>
                <Card.Text>
                  User authentication with SHA-256 password hashing and role-based access control for enhanced security.
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body className="text-center">
                <FontAwesomeIcon icon={faSyncAlt} size="3x" className="text-primary mb-3" />
                <Card.Title>Real-time Updates</Card.Title>
                <Card.Text>
                  Experience real-time updates when data changes, powered by Socket.IO for seamless collaboration.
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body className="text-center">
                <FontAwesomeIcon icon={faDatabase} size="3x" className="text-primary mb-3" />
                <Card.Title>Database Integration</Card.Title>
                <Card.Text>
                  Reliable data storage with SQL Server database, optimized for cloud deployment and scalability.
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>

      {/* Dashboard Preview */}
      <Container className="mb-5">
        <Row className="align-items-center">
          <Col md={6} className="mb-4 mb-md-0">
            <h2>Advanced Dashboard</h2>
            <p className="lead">
              Powerful analytics and management tools at your fingertips.
            </p>
            <p>
              Our intuitive dashboard provides real-time insights into your data, 
              with customizable widgets and interactive charts to help you make 
              informed decisions quickly.
            </p>
            <Button as={Link as any} to="/dashboard" variant="primary">
              Explore Dashboard
            </Button>
          </Col>
          <Col md={6}>
            <Card className="shadow">
              <Card.Img variant="top" src="/dashboard-preview.png" alt="Dashboard Preview" />
              <Card.Body className="text-center">
                <Card.Title>Dashboard Preview</Card.Title>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>

      {/* Testimonials */}
      <Container className="mb-5">
        <h2 className="text-center mb-4">What Our Users Say</h2>
        <Row>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body>
                <div className="d-flex align-items-center mb-3">
                  <img 
                    src="/user1.jpg" 
                    alt="John Doe" 
                    className="rounded-circle me-3"
                    width="50"
                    height="50"
                  />
                  <div>
                    <h5 className="mb-0">John Doe</h5>
                    <small className="text-muted">CEO, TechCorp</small>
                  </div>
                </div>
                <Card.Text>
                  "This application has transformed how our team collaborates. The real-time updates are game-changing!"
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body>
                <div className="d-flex align-items-center mb-3">
                  <img 
                    src="/user2.jpg" 
                    alt="Jane Smith" 
                    className="rounded-circle me-3"
                    width="50"
                    height="50"
                  />
                  <div>
                    <h5 className="mb-0">Jane Smith</h5>
                    <small className="text-muted">CTO, InnovateCo</small>
                  </div>
                </div>
                <Card.Text>
                  "The security features give me peace of mind, and the interface is incredibly intuitive. Highly recommended!"
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
          <Col md={4} className="mb-4">
            <Card className="h-100 shadow-sm">
              <Card.Body>
                <div className="d-flex align-items-center mb-3">
                  <img 
                    src="/user3.jpg" 
                    alt="Robert Johnson" 
                    className="rounded-circle me-3"
                    width="50"
                    height="50"
                  />
                  <div>
                    <h5 className="mb-0">Robert Johnson</h5>
                    <small className="text-muted">CIO, DataSystems</small>
                  </div>
                </div>
                <Card.Text>
                  "The dashboard analytics have provided valuable insights for our business. Setup was quick and the support is excellent."
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>

      {/* CTA Section */}
      <div className="bg-light py-5 mb-5">
        <Container className="text-center">
          <h2>Ready to Get Started?</h2>
          <p className="lead mb-4">
            Join thousands of users already benefiting from our advanced features.
          </p>
          <Button as={Link as any} to="/register" variant="primary" size="lg">
            Sign Up Now
          </Button>
        </Container>
      </div>
    </>
  );
};

export default Home;

