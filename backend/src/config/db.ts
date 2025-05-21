import { ConnectionPool } from 'mssql';
import dotenv from 'dotenv';

dotenv.config();

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

const pool = new ConnectionPool(sqlConfig);

export default pool;
