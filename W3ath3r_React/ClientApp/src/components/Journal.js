import React, { useState, useEffect } from 'react';

import './Journal.css';

export function Journal(props) {
    
    const {journalBlocksJSON} = props;
    const [isFading, setFadingState] = useState(true)
    const lastIndex = journalBlocksJSON.length - 1;
    
    useEffect(() => {
        setFadingState(true);
        setTimeout(() => {
            setFadingState(false);
        }, 20);
    }, [journalBlocksJSON[lastIndex]]);
    
    return (
        <div id="journal">
            {journalBlocksJSON.map((block, blockIndex) => (
                <div className={`${(blockIndex !== lastIndex) ? "journalBlock" : (isFading ? "journalBlockFading" : "journalBlock")}`}>
                  <p className="timestamp">{block.dateTime}</p>
                  <p>City: {block.cityName}</p>
                  <p>Temperature: {block.temp}℃</p>
                  <p>Time Zone: {block.timezoneName}</p>
                </div>
            ))}
        </div>
    );
}