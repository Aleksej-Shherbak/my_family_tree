import * as React from 'react';
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./router/AppRouter";
import {Provider} from "react-redux";
import {store} from "./redux/RootReducer";

export const App: React.FC = () =>  <Provider store={store}>
    <BrowserRouter>
        <AppRouter/>
    </BrowserRouter>
</Provider>