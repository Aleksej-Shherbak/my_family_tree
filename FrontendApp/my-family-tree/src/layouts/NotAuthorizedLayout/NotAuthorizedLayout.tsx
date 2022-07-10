import * as React from 'react';
import {FC} from 'react';
import styles from './NotAuthorizedLayout.module.scss';
import AlertComponent from "../../components/Alert/AlertComponent";
import IChildrenContainer from "../../types/IChildrenContainer";

const NotAuthorizedLayout: FC<IChildrenContainer> = ({children}) => {
    return (
        <div>
            <AlertComponent/>
            <div className={styles.notAuthorizedLayout}>
                {children}
            </div>    
        </div>
        
    );
};

export default NotAuthorizedLayout;