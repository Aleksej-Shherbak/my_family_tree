import {AnyAction, combineReducers} from "redux";
import {authReducer} from "./auth/AuthReducer";
import {alertReducer} from "./alert/AlertReducer";
import {IAppState} from "./AppStateTypes";
import {configureStore} from "@reduxjs/toolkit";
import axios from "axios";
import {BASE_URL, CHECK_IS_AUTHENTICATED} from "../constants/backend";
import {TreeReducer} from "./tree/TreeReducer";

const rootReducer = combineReducers<IAppState>({
    auth: authReducer,
    alert: alertReducer,
    trees: TreeReducer
});

(async () => {
    try {
        await axios.get(`${BASE_URL}${CHECK_IS_AUTHENTICATED}`, {withCredentials: true})
    } catch (e) {
        localStorage.removeItem('user');
    }
})();

export const store = configureStore({
    reducer: rootReducer,
})

export type AppDispatch = typeof store.dispatch