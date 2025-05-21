import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Footer: React.FC = () => {
  return (
    <footer className="bg-dark text-light py-4 mt-5">
      <Container>
        <Row>
          <Col md={3} className="mb-3">
            <h5>Mynewapp</h5>
            <p className="text-muted">
              A modern web application with real-time updates, secure authentication, and advanced features.
            </p>
          </Col>
          <Col md={3} className="mb-3">
            <h5>Features</h5>
            <ul className="list-unstyled">
              <li><Link to="/features" className="text-muted">Authentication</Link></li>
              <li><Link to="/features" className="text-muted">Real-time Updates</Link></li>
              <li><Link to="/features" className="text-muted">Database Integration</Link></li>
              <li><Link to="/features" className="text-muted">Advanced Dashboard</Link></li>
              <li><Link to="/features" className="text-muted">API Access</Link></li>
            </ul>
          </Col>
          <Col md={3} className="mb-3">
            <h5>Resources</h5>
            <ul className="list-unstyled">
              <li><Link to="/documentation" className="text-muted">Documentation</Link></li>
              <li><Link to="/documentation" className="text-muted">API Reference</Link></li>
              <li><Link to="/documentation" className="text-muted">Tutorials</Link></li>
              <li><Link to="/documentation" className="text-muted">Blog</Link></li>
              <li><Link to="/documentation" className="text-muted">Community</Link></li>
            </ul>
          </Col>
          <Col md={3} className="mb-3">
            <h5>Company</h5>
            <ul className="list-unstyled">
              <li><Link to="/about" className="text-muted">About Us</Link></li>
              <li><Link to="/careers" className="text-muted">Careers</Link></li>
              <li><Link to="/contact" className="text-muted">Contact</Link></li>
              <li><Link to="/privacy" className="text-muted">Privacy Policy</Link></li>
              <li><Link to="/terms" className="text-muted">Terms of Service</Link></li>
            </ul>
          </Col>
        </Row>
        <hr className="my-3" />
        <Row>
          <Col className="text-center text-muted">
            <p>© 2025 Mynewapp. All rights reserved.</p>
            <p>
              <Link to="/privacy" className="text-muted me-3">Privacy Policy</Link>
              <Link to="/terms" className="text-muted">Terms of Service</Link>
            </p>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default Footer;
