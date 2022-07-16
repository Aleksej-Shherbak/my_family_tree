import {Dispatch} from "redux";
import {alertActions} from "../alert/AlertActions";
import {AlertAction} from "../alert/AlertTypes";
import {GET_PERSON_LIST} from "../../constants/backend";
import {MakeRequest} from "../../infrastructure/http/MakeRequest";
import {Person} from "../../models/Person";
import {PersonActionTypes, PersonsAction} from "./PersonTypes";

export const personActions = {
    fetchList,
//    create
}

function fetchList() {
    return async (dispatch: Dispatch<PersonsAction | AlertAction>): Promise<void> => {
        try {
            const res = await MakeRequest<Person[]>(GET_PERSON_LIST, 'GET');
            if (res !== null) {
                dispatch(success(res.data));
            }
        } catch (error) {
            console.error(error);
            await dispatch(alertActions.error('Unable to load persons. Please try again later.'));
        }
    }

    function success(items: Person[]): PersonsAction {
        return {type: PersonActionTypes.PERSONS_FETCH, persons: items}
    }
}

/*function create(request: CreateTreeRequest) {
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
}*/
