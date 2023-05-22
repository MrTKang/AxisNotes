import React, { useState, useEffect } from 'react';

function CreateNote(props) {
    const [columnKey, setColumnKey] = useState("");
    const [columnValue, setColumnValue] = useState("");
    const [rowKey, setRowKey] = useState("");
    const [rowValue, setRowValue] = useState("");
    const [contentKey, setContentKey] = useState("");
    const [contentValue, setContentValue] = useState("");

    const handleSubmit = (e) => {
        fetch("notes", {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "Language": columnValue,
                "Definition": rowValue,
                "Content": contentValue
            })
        });
        e.preventDefault();
    }

    return (
        <form onSubmit={e => { handleSubmit(e) }}>
            <label>Column Value:</label>
            <input
                name='columnValue'
                type='text'
                value={columnValue}
                onChange={e => setColumnValue(e.target.value)}
            />
            <br />
            <label>Row Value:</label>
            <br />
            <input
                name='rowValue'
                type='text'
                value={rowValue}
                onChange={e => setRowValue(e.target.value)}
            />
            <br />
            <label>Content Value:</label>
            <br />
            <input
                name='setContentValue'
                type='text'
                value={contentValue}
                onChange={e => setContentValue(e.target.value)}
            />
            <br />
            <input
                type='submit'
                value='Add Note'
            />
        </form>
    );
}
export default CreateNote;