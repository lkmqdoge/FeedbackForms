<script lang="ts">
    import AnswerForm from "./AnswerForm.svelte";
import { cn } from "./utils";
    interface Props {
        className?: string;
        innerClassName?: string;
    }

    let { className, innerClassName }: Props = $props();
    let links: { link: string, name: string}[] = [
        {
            link: "/",
            name: "Home"
        },
        {
            link: "/topic/create",
            name: "Create"
        }
    ]

</script>

<div class={cn(className, "bg-secondary flex justify-center h-12")}>
    <div class={cn(innerClassName, "flex flex-col justify-end")}>
        <div class="flex gap-4">
            {#each links as a}
                <a class="button" href={a.link}>{a.name}</a>
            {/each}
        </div>
    </div>
</div>

<style>
    .button {
        background-color: var(--color-primary);
        padding: 4px;
        border-radius: 4px 4px 0px 0px;
    }
</style>
