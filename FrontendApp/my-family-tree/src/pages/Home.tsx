import * as React from 'react';
import MainLayout from "../layouts/MainLayout/MainLayout";
import FamilyTreeList from "../components/FamilyTree/FamilyTreeList";

const Home = () => {
    return (
        <MainLayout>
            <h1>This is the home page</h1>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Deserunt doloremque ducimus earum est
                laudantium omnis, perferendis quam sint? Amet aspernatur cupiditate dolorum facere iusto, labore nobis
                numquam perferendis quos ratione.</p>
            
            <FamilyTreeList/>
        </MainLayout>
    );
};

export default Home;