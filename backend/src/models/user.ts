import pool from '../config/db';
import { IUser } from '../types/user';

export const getUserById = async (id: string): Promise<IUser | null> => {
  try {
    await pool.connect();
    const result = await pool.request()
      .input('id', id)
      .query('SELECT * FROM Users WHERE id = @id');
    
    return result.recordset[0] || null;
  } catch (error) {
    console.error('Error getting user by ID:', error);
    throw error;
  }
};

export const getUserByEmail = async (email: string): Promise<IUser | null> => {
  try {
    await pool.connect();
    const result = await pool.request()
      .input('email', email)
      .query('SELECT * FROM Users WHERE email = @email');
    
    return result.recordset[0] || null;
  } catch (error) {
    console.error('Error getting user by email:', error);
    throw error;
  }
};

export const createUser = async (user: IUser): Promise<IUser> => {
  try {
    await pool.connect();
    const result = await pool.request()
      .input('firstName', user.firstName)
      .input('lastName', user.lastName)
      .input('email', user.email)
      .input('password', user.password)
      .input('role', user.role || 'user')
      .query(`
        INSERT INTO Users (firstName, lastName, email, password, role)
        OUTPUT INSERTED.*
        VALUES (@firstName, @lastName, @email, @password, @role)
      `);
    
    return result.recordset[0];
  } catch (error) {
    console.error('Error creating user:', error);
    throw error;
  }
};
