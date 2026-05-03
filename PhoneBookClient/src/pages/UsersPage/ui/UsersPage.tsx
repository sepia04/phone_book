import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/shared/ui/table"
import {Layout} from "@/app/layout";
import {useEffect, useState} from "react";
import {getUsers} from "../api/getUsers";
import type {UserDto} from "../model/types.ts";
import {Button} from "@/shared/ui/button.tsx";
import {DeleteDialog} from "@/widgets";
import {Link} from "react-router";

export const UsersPage = () => {
    const [users, setUsers] = useState<UserDto[]>([]);

    useEffect(() => {
        getUsers()
            .then((res) => {
                setUsers(res.data);
            })
            .catch((err) => {
                console.error(err);
            });
    }, []);

    return (
        <Layout>
            <div>
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead className="text-center text-xl">Name</TableHead>
                            <TableHead className="text-center text-xl">Email</TableHead>
                            <TableHead className="text-center text-xl">Date of Birth</TableHead>
                            <TableHead className="text-center text-xl">Operations</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {users.map((user) => (
                            <TableRow key={user.id}>
                                <TableCell className="text-center">{user.name}</TableCell>
                                <TableCell className="text-center">{user.email}</TableCell>
                                <TableCell className="text-center">
                                    {new Date(user.dateOfBirth).toLocaleDateString()}
                                </TableCell>
                                <TableCell className="flex gap-3 justify-center">
                                    <Button variant="outline">
                                        <Link to="update" prefetch="intent">Update</Link>
                                    </Button>
                                    <DeleteDialog entity="User" id={user.id}/>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>
        </Layout>
    )
}