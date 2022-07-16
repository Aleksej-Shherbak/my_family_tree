import {AnyAction} from "redux";
import {Person} from "../../models/Person";

export interface PersonsAction extends AnyAction {
    persons: Person[]
}

export enum PersonActionTypes {
    PERSONS_LOADING = 'PERSON_LOADING',
    PERSONS_LOADING_FINISHED = 'PERSONS_LOADING_FINISHED',
    PERSONS_FETCH = 'PERSONS_FETCH',
    PERSON_ADD = 'PERSON_ADD',
    PERSON_DELETE = 'PERSON_DELETE',
    PERSON_EDIT = 'PERSON_EDIT',
}