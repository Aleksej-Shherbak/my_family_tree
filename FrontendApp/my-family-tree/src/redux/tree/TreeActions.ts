import {Dispatch} from "redux";
import {TreeAction, TreeActionTypes} from "./TreeTypes";
import axios from "axios";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {TreeList} from "../../models/tree/TreeList";
import {BASE_URL, GET_TREE_LIST} from "../../constants/backend";
import {Tree} from "../../models/tree/Tree";

export const treeActions  = {
    treeFetchList,
}

function treeFetchList() {
    return async (dispatch: Dispatch<TreeAction|AlertAction>): Promise<void> => {
        try {
            const res = await axios.get<TreeList>(`${BASE_URL}${GET_TREE_LIST}`, {withCredentials: true})
            dispatch(success(res.data.trees));
            console.log(res);
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load trees. Please try again later.'));
        }
    }

    function success(trees: Tree[]): TreeAction {
        return {type: TreeActionTypes.TREE_GET_LIST, trees}
    }
}
