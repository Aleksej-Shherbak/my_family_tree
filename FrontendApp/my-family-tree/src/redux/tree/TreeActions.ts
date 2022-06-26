import {Dispatch} from "redux";
import {TreeAction, TreeActionTypes, TreeListAction, TreeListActionTypes} from "./TreeTypes";
import axios from "axios";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {TreeList} from "../../models/tree/TreeList";
import {BASE_URL, CREATE_TREE, GET_TREE_LIST} from "../../constants/backend";
import {Tree} from "../../models/tree/Tree";
import {BaseResponse} from "../../Responses/BaseResponse";
import {CreateTreeRequest} from "../../Requests/Tree/CreateTreeRequest";

export const treeActions = {
    treeFetchList,
    createTree
}

function treeFetchList() {
    return async (dispatch: Dispatch<TreeListAction | AlertAction>): Promise<void> => {
        try {
            const res = await axios.get<TreeList>(`${BASE_URL}${GET_TREE_LIST}`, {withCredentials: true})
            dispatch(success(res.data.trees));
            console.log(res);
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load trees. Please try again later.'));
        }
    }

    function success(trees: Tree[]): TreeListAction {
        return {type: TreeListActionTypes.TREE_GET_LIST, trees}
    }
}

function createTree(request: CreateTreeRequest) {
    return async (dispatch: Dispatch<TreeAction | AlertAction>): Promise<void> => {
        try {
            const bodyFormData = new FormData();
            if (request.image) {
                bodyFormData.append('image', request.image)
            }
            bodyFormData.append('title', request.title)
            if (request.description) {
                bodyFormData.append('description', request.description)
            }
            
            const res = await axios.post<CreateTreeRequest, BaseResponse<number>>(`${BASE_URL}${CREATE_TREE}`, bodyFormData, {withCredentials: true});
            const tree: Tree = {...request, id: res.data}
            dispatch(success(tree));
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load create new tree. Please try again later.'));
        }
    }

    function success(tree: Tree): TreeAction {
        return {type: TreeActionTypes.TREE_CREATE, tree};
    }
}
