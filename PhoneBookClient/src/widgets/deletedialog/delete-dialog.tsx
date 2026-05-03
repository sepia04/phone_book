import {
    AlertDialog,
    AlertDialogAction,
    AlertDialogCancel,
    AlertDialogContent,
    AlertDialogDescription,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle,
    AlertDialogTrigger,
} from "@/shared/ui/alert-dialog"
import {Button} from "@/shared/ui/button.tsx";
import {deleteEntity} from "@/shared/api"; // Import the function

type DeleteEntityRequest = {
    entity: string,
    id: number
}

export function DeleteDialog({entity, id}: DeleteEntityRequest) {
    const handleDelete = async () => {
        try {
            await deleteEntity(entity, id);
            console.log(`${entity} deleted successfully`);
        } catch (error) {
            console.error('Failed to delete:', error);
        }
    };

    return (<>
        <AlertDialog>
            <AlertDialogTrigger asChild>
                <Button variant="outline">Delete</Button>
            </AlertDialogTrigger>
            <AlertDialogContent>
                <AlertDialogHeader>
                    <AlertDialogTitle>Are you absolutely sure?</AlertDialogTitle>
                    <AlertDialogDescription>
                        This action cannot be undone. This will permanently delete this {entity.toLowerCase()} from
                        database.
                    </AlertDialogDescription>
                </AlertDialogHeader>
                <AlertDialogFooter>
                    <AlertDialogCancel>Cancel</AlertDialogCancel>
                    <AlertDialogAction onClick={handleDelete}>
                        Continue
                    </AlertDialogAction>
                </AlertDialogFooter>
            </AlertDialogContent>
        </AlertDialog></>)
}