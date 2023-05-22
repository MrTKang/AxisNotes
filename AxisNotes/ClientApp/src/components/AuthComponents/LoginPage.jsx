import React, { useState, useEffect } from 'react';

function LoginPage() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = (e) => {
        fetch("login", {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "username": username,
                "password": password
            })
        });
        e.preventDefault();
    }

    return (
        <div>
            <form onSubmit={e => { handleSubmit(e) }}>
                <label>Username:</label>
                <input
                    name='username'
                    type='text'
                    value={username}
                    onChange={e => setUsername(e.target.value)}
                />
                <br />
                <label>Password:</label>
                <br />
                <input
                    name='password'
                    type='text'
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                />
                <br />
                <label>Confirm Password:</label>
                <br />
                <input
                    name='confirm password'
                    type='text'
                    value={confirmPassword}
                    onChange={e => setConfirmPassword(e.target.value)}
                />
                <br />
                <input
                    type='submit'
                    value='Register User'
                />
            </form>
        </div>
    );
}
export default LoginPage;