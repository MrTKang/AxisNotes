import React, { useState, useEffect } from 'react';

function NotesTable(props) {
    return (
        <div>
            <div></div>
            <table>
                <tr><th></th>{props.notes.columnHeaders.map(header => <th>{header}</th>)}</tr>
                {props.notes.rowHeaders.map((header, i) =>
                    <tr><td>{header}</td>{props.notes.grid[i].map(row => <td>{row}</td>)}</tr>
                )
                }
            </table>
        </div>
    );
}
export default NotesTable;