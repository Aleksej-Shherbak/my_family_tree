import {combineReducers} from "redux";
import {authReducer} from "./auth/AuthReducer";
import {alertReducer} from "./alert/AlertReducer";
import {IAppState} from "./AppStateTypes";
import {TreeListReducer} from "./tree/TreeListReducer";
import {configureStore} from "@reduxjs/toolkit";

const rootReducer = combineReducers<IAppState>({
    auth: authReducer,
    alert: alertReducer,
    trees: TreeListReducer
});

export const store = configureStore({
    reducer: rootReducer,
})

export type AppDispatch = typeof store.dispatch