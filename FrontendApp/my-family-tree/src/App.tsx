import * as React from 'react';
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./router/AppRouter";
import {configureStore} from "@reduxjs/toolkit";
import {rootReducer} from "./redux/RootReducer";
import {Provider} from "react-redux";

const store = configureStore({
    reducer: rootReducer,
})

export const app = <Provider store={store}>
    <BrowserRouter>
        <AppRouter/>
    </BrowserRouter>
</Provider>