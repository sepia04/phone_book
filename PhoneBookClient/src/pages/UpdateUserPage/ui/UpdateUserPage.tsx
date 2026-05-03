"use client"

import * as React from "react"
import {zodResolver} from "@hookform/resolvers/zod"
import {Controller, useForm} from "react-hook-form"
import {toast} from "sonner"
import * as z from "zod"

import {Layout} from "@/app/layout";

import {Button} from "@/shared/ui/button"
import {
    Card,
    CardContent,
    CardFooter,
    CardHeader,
    CardTitle,
} from "@/shared/ui/card"
import {
    Field,
    FieldError,
    FieldGroup,
    FieldLabel,
} from "@/shared/ui/field"
import {Input} from "@/shared/ui/input"
import {
    InputGroup,
} from "@/shared/ui/input-group"
import {DatePicker} from "@/widgets/datepicker/date-picker.tsx";

const formSchema = z.object({
    name: z
        .string()
        .min(3, "User name must be at least 3 characters.")
        .max(32, "User name must be at most 32 characters."),
    email: z
        .string()
        .trim()
        .toLowerCase()
        .email("Invalid email address."),
    dateOfBirth: z
        .date()
        .min(new Date("1900-01-01"), "Date must be after 1900-01-01.")
        .max(new Date(), "Date cannot be in the future."),
})

export const UpdateUserPage = () => {
    return (
        <Layout>
            <div className="flex items-center justify-center">
                <div className="w-full">
                    <h1 className="text-center mb-8 text-2xl font-bold">Form Update User</h1>
                    <div className="flex justify-center">
                        <UpdateUserForm/>
                    </div>
                </div>
            </div>
        </Layout>
    )
}

export function UpdateUserForm() {
    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            name: "",
            email: "",
            dateOfBirth: undefined,
        },
    })

    function onSubmit(data: z.infer<typeof formSchema>) {
        toast("You submitted the following values:", {
            description: (
                <pre className="mt-2 w-[320px] overflow-x-auto rounded-md bg-code p-4 text-code-foreground">
          <code>{JSON.stringify(data, null, 2)}</code>
        </pre>
            ),
            position: "bottom-right",
            classNames: {
                content: "flex flex-col gap-2",
            },
            style: {
                "--border-radius": "calc(var(--radius)  + 4px)",
            } as React.CSSProperties,
        })
    }

    return (
        <Card className="w-full sm:max-w-md">
            <CardHeader>
                <CardTitle>Update User</CardTitle>
            </CardHeader>
            <CardContent>
                <form id="form-rhf-demo" onSubmit={form.handleSubmit(onSubmit)}>
                    <FieldGroup>
                        <Controller
                            name="name"
                            control={form.control}
                            render={({field, fieldState}) => (
                                <Field data-invalid={fieldState.invalid}>
                                    <FieldLabel htmlFor="form-rhf-name">
                                        Name
                                    </FieldLabel>
                                    <Input
                                        {...field}
                                        id="form-rhf-name"
                                        aria-invalid={fieldState.invalid}
                                        autoComplete="off"
                                    />
                                    {fieldState.invalid && (
                                        <FieldError errors={[fieldState.error]}/>
                                    )}
                                </Field>
                            )}
                        />
                        <Controller
                            name="email"
                            control={form.control}
                            render={({field, fieldState}) => (
                                <Field data-invalid={fieldState.invalid}>
                                    <FieldLabel htmlFor="form-rhf-email">
                                        Email
                                    </FieldLabel>
                                    <InputGroup>
                                        <Input
                                            {...field}
                                            id="form-rhf-email"
                                            aria-invalid={fieldState.invalid}
                                            autoComplete="off"
                                        />
                                    </InputGroup>
                                    {fieldState.invalid && (
                                        <FieldError errors={[fieldState.error]}/>
                                    )}
                                </Field>
                            )}
                        />
                        <Controller
                            name="dateOfBirth"
                            control={form.control}
                            render={({field, fieldState}) => (
                                <Field data-invalid={fieldState.invalid}>
                                    <FieldLabel htmlFor="form-rhf-dob">
                                        Date of Birth
                                    </FieldLabel>
                                    <InputGroup>
                                        <DatePicker
                                            value={field.value}
                                            onChange={field.onChange}
                                        />
                                    </InputGroup>
                                    {fieldState.invalid && (
                                        <FieldError errors={[fieldState.error]}/>
                                    )}
                                </Field>
                            )}
                        />
                    </FieldGroup>
                </form>
            </CardContent>
            <CardFooter>
                <Field orientation="horizontal">
                    <Button type="button" variant="outline" onClick={() => form.reset()}>
                        Reset
                    </Button>
                    <Button type="submit" form="form-rhf-demo">
                        Create
                    </Button>
                </Field>
            </CardFooter>
        </Card>
    )
}