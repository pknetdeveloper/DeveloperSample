import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = ({ onSubmit }) => {
    const [formData, setFormData] = useState({ login: '', password: '' });

    const handleSubmit = (e) => {
        e.preventDefault();
        if (formData.login && formData.password) {
            onSubmit(formData);
            setFormData({ login: '', password: '' });
        }
    };

    const handleChange = (e) => {
        setFormData(prev => ({
            ...prev,
            [e.target.name]: e.target.value
        }));
    };

    return (
        <div className="form">
            <h1>Login</h1>
            <label htmlFor="login">Name</label>
            <input type="text" id="login" name="login" value={formData.login} onChange={handleChange} />
            <label htmlFor="password">Password</label>
            <input type="password" id="password" name="password" value={formData.password} onChange={handleChange} />
            <button type="submit" onClick={handleSubmit}>Continue</button>
        </div>
    );
};

export default LoginForm;