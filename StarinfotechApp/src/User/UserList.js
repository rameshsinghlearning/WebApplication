import React, { useState, useEffect } from "react";
import axios from "axios";

const UserList = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        axios.get("http://localhost:5211/api/user").then((res) => {
            setUsers(res.data);
        }).catch(err => {
            console.log(err)
        })
    }, []);
    
    return (
        <section className="mt-5">
            <div className="container-fluid">
                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-body">
                                <h4 className="card-title">Users</h4>
                                <table className="table table-hover table-bordered table-sm">
                                    <thead className="table-dark">
                                        <tr>
                                            <th>Action</th>
                                            <th>ID</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Username</th>
                                            <th>Email</th>
                                            <th>Mobile No</th>
                                            <th>Role</th>
                                            <th>Is Active</th>
                                            <th>Added Date</th>
                                            <th>Added By</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {users.map(user => (
                                            <tr>
                                                <td>
                                                    <a asp-action="View" asp-controller="Users" asp-route-id="@user.Id" title="View">
                                                        <i className="fa fa-info-circle fa-2x text-info"></i>
                                                    </a>&nbsp;
                                                    <a asp-action="Edit" asp-controller="Users" asp-route-id="@user.Id" title="Edit">
                                                        <i className="fa fa-pencil fa-2x text-primary"></i>
                                                    </a>&nbsp;
                                                    <a asp-action="Delete" asp-controller="Users" asp-route-id="@user.Id" title="Delete">
                                                        <i className="fa fa-trash fa-2x text-danger"></i>
                                                    </a>
                                                </td>
                                                <td>{user.id}</td>
                                                <td>{user.firstName}</td>
                                                <td>{user.lastName}</td>
                                                <td>{user.username}</td>
                                                <td>{user.email}</td>
                                                <td>{user.mobileNo}</td>
                                                <td>{user.role}</td>
                                                <td>
                                                    {user.isActive ?
                                                        (<span className="badge bg-primary">Yes</span>) :
                                                        (<span className="badge bg-secondary">No</span>)}
                                                </td>
                                                <td>{user.addedDate}</td>
                                                <td>{user.addedBy}</td>
                                            </tr>
                                        ))
                                        }
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default UserList;