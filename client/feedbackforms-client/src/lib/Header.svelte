<script lang="ts">
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
                <a class="text-primary text-xl p-2 font-sans" href={a.link}>{a.name}</a>
            {/each}
        </div>
    </div>
</div>
