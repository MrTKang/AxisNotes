import React, { useState, useEffect } from 'react';

function LoginRegisterPage(props) {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    

    const handleSubmit = (e) =>
    {
        if (props.isRegister) {
            fetch("user/register", {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    "username": username,
                    "password": password,
                    "confirmPassword": confirmPassword
                })
            });
        }
        else {
            fetch("user/login", {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    "username": username,
                    "password": password
                })
            });
        }
        e.preventDefault();
    }

    return (
        <div>
            <form onSubmit={e => { handleSubmit(e) }}>
                <label>Username:</label>
                <br/>
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
                {props.isRegister && <>
                    <label>Confirm Password:</label>
                    <br />
                    <input
                        name='confirm password'
                        type='text'
                        value={confirmPassword}
                        onChange={e => setConfirmPassword(e.target.value)}
                    />
                    <br />
                </>}
                <input
                    type='submit'
                    value='Register User'
                />
            </form>
        </div>
    );
}
export default LoginRegisterPage;