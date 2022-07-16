import {Dispatch} from "redux";
import {TreeListAction, TreeListActionTypes} from "./TreeTypes";
import axios, {AxiosResponse} from "axios";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {BASE_URL, CREATE_TREE, GET_TREE_LIST} from "../../constants/backend";
import {Tree} from "../../models/tree/Tree";
import {CreateTreeRequest} from "../../Requests/Tree/CreateTreeRequest";
import {TreeResponse} from "../../Responses/tree/TreeResponse";
import {MakeRequest} from "../../infrastructure/http/MakeRequest";

export const treeActions = {
    treeFetchList,
    createTree
}

function treeFetchList() {
    return async (dispatch: Dispatch<TreeListAction | AlertAction>): Promise<void> => {
        try {
            const res = await MakeRequest<Tree[]>(GET_TREE_LIST, 'GET');
            if (res !== null) {
                dispatch(success(res.data));
            }
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load trees. Please try again later.'));
        }
    }

    function success(trees: Tree[]): TreeListAction {
        return {type: TreeListActionTypes.TREE_FETCH_LIST, trees}
    }
}

function createTree(request: CreateTreeRequest) {
    return async (dispatch: Dispatch<TreeListAction | AlertAction>): Promise<void> => {
        try {
            const bodyFormData = new FormData();
            if (request.image) {
                bodyFormData.append('image', request.image)
            }
            bodyFormData.append('title', request.title)
            if (request.description) {
                bodyFormData.append('description', request.description)
            }

            const res = await axios.post<CreateTreeRequest, AxiosResponse<TreeResponse>>(`${BASE_URL}${CREATE_TREE}`, bodyFormData, {withCredentials: true});
            const tree: Tree = {...res.data}
            dispatch(success([tree]));
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load create new tree. Please try again later.'));
        }
    }

    function success(trees: Tree[]): TreeListAction {
        return {type: TreeListActionTypes.TREE_ADD, trees};
    }
}
