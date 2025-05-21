"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const cors_1 = __importDefault(require("cors"));
const helmet_1 = __importDefault(require("helmet"));
const morgan_1 = __importDefault(require("morgan"));
const http_1 = require("http");
const socket_io_1 = require("socket.io");
const dotenv_1 = __importDefault(require("dotenv"));
const db_1 = __importDefault(require("./config/db"));
// Load environment variables
dotenv_1.default.config();
// Initialize Express app
const app = (0, express_1.default)();
const PORT = process.env.PORT || 3001;
// Middleware
app.use((0, cors_1.default)());
app.use((0, helmet_1.default)());
app.use((0, morgan_1.default)('dev'));
app.use(express_1.default.json());
app.use(express_1.default.urlencoded({ extended: true }));
// Create HTTP server
const httpServer = (0, http_1.createServer)(app);
// Initialize Socket.IO
const io = new socket_io_1.Server(httpServer, {
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
db_1.default.connect().then(() => {
    console.log('Connected to SQL Server');
}).catch(err => {
    console.error('Database connection failed:', err);
});
// Routes
const auth_1 = __importDefault(require("./routes/auth"));
app.use('/api/auth', auth_1.default);
app.get('/', (req, res) => {
    res.json({ message: 'Welcome to Mynewapp API' });
});
// Start server
httpServer.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
