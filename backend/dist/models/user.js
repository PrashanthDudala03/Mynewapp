"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.createUser = exports.getUserByEmail = exports.getUserById = void 0;
const db_1 = __importDefault(require("../config/db"));
const getUserById = (id) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield db_1.default.connect();
        const result = yield db_1.default.request()
            .input('id', id)
            .query('SELECT * FROM Users WHERE id = @id');
        return result.recordset[0] || null;
    }
    catch (error) {
        console.error('Error getting user by ID:', error);
        throw error;
    }
});
exports.getUserById = getUserById;
const getUserByEmail = (email) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield db_1.default.connect();
        const result = yield db_1.default.request()
            .input('email', email)
            .query('SELECT * FROM Users WHERE email = @email');
        return result.recordset[0] || null;
    }
    catch (error) {
        console.error('Error getting user by email:', error);
        throw error;
    }
});
exports.getUserByEmail = getUserByEmail;
const createUser = (user) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield db_1.default.connect();
        const result = yield db_1.default.request()
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
    }
    catch (error) {
        console.error('Error creating user:', error);
        throw error;
    }
});
exports.createUser = createUser;
