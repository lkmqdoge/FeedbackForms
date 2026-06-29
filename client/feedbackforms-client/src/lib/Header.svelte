<script lang="ts">
    import { cn } from "./utils";
    interface Props {
        className?: string;
        innerClassName?: string;
        links: { link: string, name: string }[]
        userName?: string;
    }
    let {
        className,
        innerClassName,
        links,
        userName,
    }: Props = $props();
</script>

<div class={cn(className, "bg-secondary flex h-12 px-4 justify-center")}>
    <div class={cn(innerClassName, "flex justify-between items-center")}>
        <div class="flex gap-4">
            {#each links as a}
                <a class="text-primary text-xl p-2 font-serif" href={a.link}>{a.name}</a>
            {/each}
        </div>
        <div class="flex">
            {#if userName}
                <form method="POST" action="/logout"
                    class="inline-flex justify-center text-supporting items-center bg-transparent border-0 cursor-pointer hover:underline">
                    <button type="submit">Log Out</button>
                </form>
                <a class="text-accennt text-xl p-2 font-sans" href="/dashboard">{userName}</a>
            {:else}
                <a class="text-primary text-xl p-2 font-sans" href="/register">register</a>
                <a class="text-primary text-xl p-2 font-sans" href="/login">login</a>
            {/if}
        </div>
    </div>
</div>

