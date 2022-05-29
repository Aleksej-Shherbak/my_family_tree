import * as React from 'react';
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./router/AppRouter";

export default function App() {
    return (
        <div>
            <BrowserRouter>
                <AppRouter/>
            </BrowserRouter>
        </div>
    );
}
