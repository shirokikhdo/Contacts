import React from "react";
import { Link } from "react-router-dom";

const RowTableContact = (props) =>{
    return(
        <tr>
            <th>{props.id}</th>
            <th>{props.name}</th>
            <th>{props.email}</th>
            <th>
                <Link
                    className="btn btn-primary btn-sm"
                    to={`/contact/${props.id}`}>
                        Подробнее
                </Link>
            </th>
        </tr>
    )
}

export default RowTableContact;