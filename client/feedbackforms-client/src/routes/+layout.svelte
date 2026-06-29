<script lang="ts">
	import './layout.css';
	import favicon from '$lib/assets/favicon.svg';
    import Header from '$lib/Header.svelte';
    import type { LayoutProps } from './$types';

	let { children, data }: LayoutProps = $props();
</script>

<svelte:head><link rel="icon" href={favicon} /></svelte:head>

<div class="bg-primary h-full min-h-screen flex-col flex gap-y-16">
    <Header 
        userName={data.userName}
        links={[
            {
                link: "/",
                name: "Home"
            },
            {
                link: "/topics/create",
                name: "Create"
            }
        ]}
        innerClassName="w-5xl"
    />

    <div class="flex justify-center items-center">
        <div class="w-5xl">
            {@render children()}
        </div>
    </div>
</div>


