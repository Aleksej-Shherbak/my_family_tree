import React, {useEffect} from 'react';
import {useParams} from "react-router-dom";
import MainLayout from "../../layouts/MainLayout/MainLayout";

const TreeDetail = () => {
    const { id } = useParams();

    useEffect(() => {
        alert(id)
    }, []);
    
    return (
        <MainLayout>
            <div>{id}</div>
        </MainLayout>
    );
};

export default TreeDetail;
