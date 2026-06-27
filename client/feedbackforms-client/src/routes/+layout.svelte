<script lang="ts">
	import './layout.css';
	import favicon from '$lib/assets/favicon.svg';
    import Header from '$lib/Header.svelte';

	let { children } = $props();
</script>

<svelte:head><link rel="icon" href={favicon} /></svelte:head>

<div class="bg-primary h-full min-h-screen flex-col flex gap-y-16">
    <Header innerClassName="w-5xl" />
    <div class="flex justify-center items-center">
        <div class="w-5xl">
            {@render children()}
        </div>
    </div>
</div>


