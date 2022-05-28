import * as React from 'react';
import {BrowserRouter} from "react-router-dom";
import MainLayout from "./pages/Layouts/MainLayout/MainLayout";

export default function App() {

    return (
        <div>
            <BrowserRouter>
                <MainLayout/>
            </BrowserRouter>
        </div>
    );
}
