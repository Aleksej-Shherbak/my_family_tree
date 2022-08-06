import {Person} from "../../models/Person";

// Person list
export enum PersonListTypes {
    REQUEST_STARTED = 'PERSON_LIST_REQUEST_STARTED',
    REQUEST_SUCCEEDED = 'PERSONS_LIST_REQUEST_SUCCEEDED',
    REQUEST_FAILED = 'PERSONS_LIST_REQUEST_FAILED',
    SET_LIST = 'PERSONS_LIST_SET_LIST'
}

export type TPersonList = 
    |
    {
        type: PersonListTypes.REQUEST_STARTED,
    }
    |
    {
        type: PersonListTypes.REQUEST_FAILED,
        payload: string
    }
    |
    {
        type: PersonListTypes.REQUEST_SUCCEEDED,
    }
    |
    {
        type: PersonListTypes.SET_LIST,
        payload: Person[]
    };

// Person item
export enum PersonTypes {
    REQUEST_STARTED = 'PERSON_REQUEST_STARTED',
    REQUEST_SUCCEEDED = 'PERSONS_REQUEST_SUCCEEDED',
    REQUEST_FAILED = 'PERSONS_REQUEST_FAILED',
    ADD = 'PERSON_ADD',
    EDIT = 'PERSON_EDIT',
    DELETE = 'PERSON_DELETE',
}

export type TPersonItem = 
    |
    {
        type: PersonTypes.REQUEST_STARTED    
    }
    |
    {
        type: PersonTypes.REQUEST_SUCCEEDED
    }
    |
    {
        type: PersonTypes.REQUEST_FAILED,
        payload: string
    }
    |
    {
        type: PersonTypes.ADD,
        payload: Person
    }
    |
    {
        type: PersonTypes.EDIT,
        payload: Person
    }
    |
    {
        type: PersonTypes.DELETE,
        payload: Person
    };

export type TPerson = 
    | TPersonList
    | TPersonItem;