const sql = require('mssql');

const config = {
  user: 'sa',
  password: '',
  database: 'master',
  server: 'IT-L14-02\INSTANCE1',
  pool: {
    max: 10,
    min: 0,
    idleTimeoutMillis: 30000
  },
  options: {
    encrypt: true,
    trustServerCertificate: true,
    connectTimeout: 30000,
    requestTimeout: 30000
  }
};

console.log('Attempting to connect to SQL Server with config:', {
  server: config.server,
  database: config.database,
  user: config.user
});

async function testConnection() {
  try {
    // Connect to SQL Server
    await sql.connect(config);
    console.log('Connected to SQL Server successfully!');
    
    // Query SQL Server version
    const result = await sql.querySELECT @@VERSION AS Version;
    console.log('SQL Server Version:', result.recordset[0].Version);
    
    // List all databases
    const dbResult = await sql.querySELECT name FROM sys.databases;
    console.log('Available databases:');
    dbResult.recordset.forEach(db => {
      console.log('- ' + db.name);
    });
    
    // Close connection
    await sql.close();
    console.log('Connection closed');
  } catch (err) {
    console.error('Error connecting to SQL Server:', err);
    console.error('Error details:', err.message);
    if (err.originalError) {
      console.error('Original error:', err.originalError.message);
    }
  }
}

testConnection();
