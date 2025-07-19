import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
    const [loginAttempts, setLoginAttempts] = useState([]);

    const handleLogin = ({ login, password }) => {
        const attempt = {
            id: login + Date.now(),
            username: login,
            timestamp: Date.now()
        };

        setLoginAttempts(old => [attempt, ...old]);
    };

    return (
        <div className="App">
            <LoginForm onSubmit={handleLogin} />
            <LoginAttemptList attempts={loginAttempts} />
        </div>
    );
};

export default App;