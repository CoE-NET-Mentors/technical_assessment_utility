import React, { useEffect, useState } from 'react';

export function RoadmapVisualizerComponent() {
    const [topics, setTopics] = useState([]);

    useEffect(() => {
        fetch('/roadmaps/net')
            .then(res => res.json())
            .then(data => setTopics(data.topics || []))
            .catch(console.error);
    }, []);

    const renderTopics = (items) => (
        <ul>
            {items.map(t => (
                <li key={t.id}>
                    {t.id}
                    {t.subtopics?.length > 0 && renderTopics(t.subtopics)}
                </li>
            ))}
        </ul>
    );

    return <div>{topics.length ? renderTopics(topics) : 'Loading...'}</div>;
}
