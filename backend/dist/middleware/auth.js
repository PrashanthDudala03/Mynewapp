"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.admin = exports.auth = void 0;
const jsonwebtoken_1 = __importDefault(require("jsonwebtoken"));
const auth = (req, res, next) => {
    // Get token from header
    const token = req.header('x-auth-token');
    // Check if no token
    if (!token) {
        res.status(401).json({ message: 'No token, authorization denied' });
        return;
    }
    try {
        // Verify token
        const decoded = jsonwebtoken_1.default.verify(token, process.env.JWT_SECRET || 'your_jwt_secret_key_here');
        // Add user from payload to request
        req.user = decoded;
        next();
    }
    catch (error) {
        res.status(401).json({ message: 'Token is not valid' });
    }
};
exports.auth = auth;
const admin = (req, res, next) => {
    if (!req.user || req.user.role !== 'admin') {
        res.status(403).json({ message: 'Access denied, admin privileges required' });
        return;
    }
    next();
};
exports.admin = admin;
