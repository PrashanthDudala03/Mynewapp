"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const mssql_1 = require("mssql");
const dotenv_1 = __importDefault(require("dotenv"));
dotenv_1.default.config();
const sqlConfig = {
    user: process.env.DB_USER || 'sa',
    password: process.env.DB_PASSWORD || '',
    database: process.env.DB_NAME || 'Mynewapp-DB',
    server: process.env.DB_SERVER || 'IT-L14-02\INSTANCE1',
    pool: {
        max: 10,
        min: 0,
        idleTimeoutMillis: 30000
    },
    options: {
        encrypt: true,
        trustServerCertificate: true,
        connectTimeout: 30000,
        requestTimeout: 30000,
        // Debug options
        debug: {
            packet: true,
            data: true,
            payload: true,
            token: false,
            log: true
        }
    }
};
console.log('SQL Server connection config:', {
    server: sqlConfig.server,
    database: sqlConfig.database,
    user: sqlConfig.user
});
const pool = new mssql_1.ConnectionPool(sqlConfig);
exports.default = pool;
