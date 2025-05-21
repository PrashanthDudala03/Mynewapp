import express from 'express';
import cors from 'cors';
import helmet from 'helmet';
import morgan from 'morgan';
import { createServer } from 'http';
import { Server } from 'socket.io';
import dotenv from 'dotenv';
import pool from './config/db';

// Load environment variables
dotenv.config();

// Initialize Express app
const app = express();
const PORT = process.env.PORT || 3001;

// Middleware
app.use(cors());
app.use(helmet());
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Create HTTP server
const httpServer = createServer(app);

// Initialize Socket.IO
const io = new Server(httpServer, {
  cors: {
    origin: '*',
    methods: ['GET', 'POST']
  }
});

// Socket.IO connection handler
io.on('connection', (socket) => {
  console.log('A user connected:', socket.id);

  socket.on('disconnect', () => {
    console.log('User disconnected:', socket.id);
  });
});

// Test database connection
pool.connect().then(() => {
  console.log('Connected to SQL Server');
}).catch(err => {
  console.error('Database connection failed:', err);
});

// Routes
import authRoutes from './routes/auth';
app.use('/api/auth', authRoutes);

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to Mynewapp API' });
});

// Start server
httpServer.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
