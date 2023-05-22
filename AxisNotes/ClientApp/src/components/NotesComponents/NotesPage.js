import React, { useState, useEffect } from 'react';
import CreateNote from './CreateNote'
import NotesTable from './NotesTable'

function NotesPage(props) {

    const [notes, setNotes] = useState({ columnHeaders: [], rowHeaders:[], grid:[[]]});

    useEffect(() => {
        async function fetchData() {
            let response = await fetch('notes');
            let responseNotes = await response.json();
            console.log(responseNotes);
            setNotes(responseNotes);
        }
        fetchData();
    }, []);

    return (
        <div>
            Note Page
            <NotesTable notes={ notes }></NotesTable>
            <CreateNote></CreateNote>
        </div>
    );
}
export default NotesPage;