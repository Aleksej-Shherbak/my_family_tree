import * as React from 'react';
import MainLayout from "../layouts/MainLayout/MainLayout";
import FamilyTreeList from "../components/FamilyTree/FamilyTreeList";

const Home = () => {
    return (
        <MainLayout>
            <h1>You family trees</h1>
            <FamilyTreeList/>
        </MainLayout>
    );
};

export default Home;