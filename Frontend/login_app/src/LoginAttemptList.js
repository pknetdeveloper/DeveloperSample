import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ attempt }) => (
    <li>
        {attempt.username} - {new Date(attempt.timestamp).toLocaleString()}
    </li>
);

const LoginAttemptList = ({ attempts }) => {
    const [filterText, setFilterText] = useState('');

    const filteredAttempts = attempts.filter(attempt =>
        attempt.username.toLowerCase().includes(filterText.toLowerCase())
    );

    return (
        <div className="Attempt-List-Main">
            <p>Recent activity</p>
            <input type="text" placeholder="Filter..." value={filterText} onChange={(e) => setFilterText(e.target.value)} />
            <ul className="Attempt-List">
                {filteredAttempts.length > 0
                    ? (filteredAttempts.map(attempt => (<LoginAttempt key={attempt.id} attempt={attempt} />)))
                    : (<li>{filterText ? 'No matching attempts' : 'No attempts yet'}</li>)}
            </ul>
        </div>
    );
};

export default LoginAttemptList;