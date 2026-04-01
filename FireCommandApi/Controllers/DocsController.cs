using Microsoft.AspNetCore.Mvc;
namespace FireCommandApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("")]
    public class DocsController : Controller
    {
        [HttpGet("")]
        public ContentResult Index()
        {
            const string html = @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    <title>FireCommand — API Docs</title>
    <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
    <link href=""https://fonts.googleapis.com/css2?family=Oswald:wght@400;500;600;700&family=JetBrains+Mono:wght@400;500&family=Inter:wght@300;400;500&display=swap"" rel=""stylesheet"">
    <style>
        :root {
            --fire-red:     #FF3B1F;
            --fire-orange:  #FF6A00;
            --fire-amber:   #FFB300;
            --ember:        #FF8C00;
            --smoke:        #1C1C1E;
            --ash:          #2A2A2E;
            --cinder:       #3A3A3E;
            --steel:        #4A4A52;
            --fog:          #9A9AA8;
            --white-smoke:  #F0EEE8;
            --success:      #2ECC71;
            --info:         #3498DB;

            --font-display: 'Oswald', sans-serif;
            --font-mono:    'JetBrains Mono', monospace;
            --font-body:    'Inter', sans-serif;
        }

        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

        body {
            background-color: var(--smoke);
            color: var(--white-smoke);
            font-family: var(--font-body);
            font-size: 14px;
            min-height: 100vh;
            overflow-x: hidden;
        }

        /* ── BACKGROUND TEXTURE ── */
        body::before {
            content: '';
            position: fixed; inset: 0;
            background:
                radial-gradient(ellipse 80% 50% at 50% -10%, rgba(255,59,31,.18) 0%, transparent 60%),
                repeating-linear-gradient(0deg, transparent, transparent 39px, rgba(255,255,255,.03) 40px),
                repeating-linear-gradient(90deg, transparent, transparent 39px, rgba(255,255,255,.015) 40px);
            pointer-events: none;
            z-index: 0;
        }

        /* ── HEADER ── */
        header {
            position: sticky; top: 0; z-index: 100;
            background: rgba(28,28,30,.92);
            backdrop-filter: blur(16px);
            border-bottom: 2px solid var(--fire-red);
            padding: 0 2rem;
            display: flex; align-items: center; gap: 1.5rem;
            height: 64px;
            box-shadow: 0 4px 32px rgba(255,59,31,.2);
        }

        .logo {
            display: flex; align-items: center; gap: .75rem;
            text-decoration: none;
        }

        .logo-icon {
            width: 36px; height: 36px;
            background: var(--fire-red);
            clip-path: polygon(50% 0%, 80% 30%, 100% 60%, 75% 85%, 50% 100%, 25% 85%, 0% 60%, 20% 30%);
            display: grid; place-items: center;
            font-size: 18px;
            animation: pulse-fire 2s ease-in-out infinite;
            flex-shrink: 0;
        }

        @keyframes pulse-fire {
            0%, 100% { box-shadow: 0 0 0 0 rgba(255,59,31,.5); }
            50%       { box-shadow: 0 0 0 8px rgba(255,59,31,.0); }
        }

        .logo-text {
            font-family: var(--font-display);
            font-size: 1.5rem; font-weight: 700;
            letter-spacing: .08em;
            color: var(--white-smoke);
        }

        .logo-text span { color: var(--fire-red); }

        .header-badge {
            margin-left: auto;
            font-family: var(--font-mono);
            font-size: .7rem;
            background: rgba(255,59,31,.15);
            border: 1px solid rgba(255,59,31,.4);
            color: var(--fire-orange);
            padding: .25rem .75rem;
            border-radius: 999px;
            letter-spacing: .06em;
        }

        .status-dot {
            width: 7px; height: 7px; border-radius: 50%;
            background: var(--success);
            box-shadow: 0 0 6px var(--success);
            display: inline-block; margin-right: .4rem;
            animation: blink 1.8s ease-in-out infinite;
        }

        @keyframes blink { 50% { opacity: .4; } }

        /* ── LAYOUT ── */
        .layout {
            position: relative; z-index: 1;
            display: grid;
            grid-template-columns: 260px 1fr;
            min-height: calc(100vh - 64px);
            min-width: 0;
        }

        /* ── SIDEBAR ── */
        aside {
            background: rgba(42,42,46,.7);
            border-right: 1px solid var(--cinder);
            padding: 1.5rem 0;
            position: sticky; top: 64px;
            height: calc(100vh - 64px);
            overflow-y: auto;
            scrollbar-width: thin;
            scrollbar-color: var(--cinder) transparent;
        }

        .sidebar-section {
            margin-bottom: 1.5rem;
        }

        .sidebar-title {
            font-family: var(--font-display);
            font-size: .65rem;
            letter-spacing: .14em;
            color: var(--fog);
            padding: .25rem 1.5rem .5rem;
            text-transform: uppercase;
        }

        .sidebar-item {
            display: flex; align-items: center; gap: .6rem;
            padding: .55rem 1.5rem;
            cursor: pointer;
            transition: background .15s, color .15s;
            border-left: 3px solid transparent;
            font-size: .8rem; color: var(--fog);
        }

        .sidebar-item:hover {
            background: rgba(255,59,31,.08);
            color: var(--white-smoke);
            border-left-color: var(--fire-red);
        }

        .sidebar-item.active {
            background: rgba(255,59,31,.14);
            color: var(--white-smoke);
            border-left-color: var(--fire-red);
        }

        .sidebar-item .method-pill {
            font-family: var(--font-mono);
            font-size: .6rem; font-weight: 500;
            padding: .1rem .45rem;
            border-radius: 3px;
            min-width: 40px; text-align: center;
            flex-shrink: 0;
        }

        /* ── MAIN ── */
        main {
            padding: 2rem 2.5rem;
            width: 100%;
            min-width: 0;
        }

        .page-title {
            font-family: var(--font-display);
            font-size: 2.2rem; font-weight: 700;
            letter-spacing: .04em;
            margin-bottom: .5rem;
        }

        .page-title em {
            font-style: normal;
            background: linear-gradient(90deg, var(--fire-red), var(--fire-amber));
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }

        .page-desc {
            color: var(--fog);
            font-size: .9rem;
            margin-bottom: 2rem;
            line-height: 1.6;
            max-width: 720px;
        }

        /* ── TAG GROUP ── */
        .tag-group { margin-bottom: 0; }

        /* ── TWO-COLUMN GRID ── */
        #endpoints-container {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 0 1.5rem;
            align-items: start;
        }

        #col-left, #col-right {
            display: flex;
            flex-direction: column;
            min-width: 0;
        }

        .tag-header {
            display: flex; align-items: center; gap: .75rem;
            margin-bottom: .75rem;
            padding-bottom: .5rem;
            border-bottom: 1px solid var(--cinder);
        }

        .tag-icon { font-size: 1.2rem; }

        .tag-name {
            font-family: var(--font-display);
            font-size: 1.1rem; font-weight: 600;
            letter-spacing: .06em;
            text-transform: uppercase;
        }

        .tag-count {
            font-family: var(--font-mono);
            font-size: .7rem;
            color: var(--fog);
            margin-left: auto;
        }

        /* ── ENDPOINT CARD ── */
        .endpoint-card {
            background: rgba(42,42,46,.6);
            border: 1px solid var(--cinder);
            border-radius: 6px;
            margin-bottom: .5rem;
            overflow: hidden;
            transition: border-color .2s, box-shadow .2s;
        }

        .endpoint-card:hover { border-color: var(--steel); }
        .endpoint-card.open  { border-color: var(--fire-orange); box-shadow: 0 0 0 1px rgba(255,106,0,.3); }

        .endpoint-header {
            display: flex; align-items: center; gap: .75rem;
            padding: .75rem 1rem;
            cursor: pointer;
            user-select: none;
        }

        .method-badge {
            font-family: var(--font-mono);
            font-size: .7rem; font-weight: 500;
            padding: .25rem .65rem;
            border-radius: 4px;
            min-width: 56px; text-align: center;
            flex-shrink: 0; letter-spacing: .04em;
        }

        .method-GET    { background: rgba(46,204,113,.18); color: #2ECC71; border: 1px solid rgba(46,204,113,.4); }
        .method-POST   { background: rgba(52,152,219,.18); color: #3498DB; border: 1px solid rgba(52,152,219,.4); }
        .method-PUT    { background: rgba(255,179,0,.18);  color: #FFB300; border: 1px solid rgba(255,179,0,.4); }
        .method-PATCH  { background: rgba(255,106,0,.18);  color: #FF6A00; border: 1px solid rgba(255,106,0,.4); }
        .method-DELETE { background: rgba(255,59,31,.18);  color: #FF3B1F; border: 1px solid rgba(255,59,31,.4); }

        .endpoint-path {
            font-family: var(--font-mono);
            font-size: .82rem;
            color: var(--white-smoke);
            flex: 1;
        }

        .endpoint-summary {
            font-size: .8rem;
            color: var(--fog);
            margin-left: auto;
            max-width: 240px;
            text-align: right;
            white-space: nowrap; overflow: hidden; text-overflow: ellipsis;
        }

        .chevron {
            color: var(--fog); font-size: .8rem;
            transition: transform .2s;
            flex-shrink: 0;
        }
        .open .chevron { transform: rotate(180deg); }

        /* ── ENDPOINT BODY ── */
        .endpoint-body {
            display: grid;
            grid-template-rows: 0fr;
            transition: grid-template-rows .32s cubic-bezier(.4,0,.2,1);
            border-top: 0px solid var(--cinder);
            overflow: hidden;
        }

        .endpoint-body-inner {
            overflow: hidden;
            padding: 0 1.25rem;
            transition: padding .32s cubic-bezier(.4,0,.2,1);
        }

        .open .endpoint-body {
            grid-template-rows: 1fr;
            border-top-width: 1px;
        }

        .open .endpoint-body-inner {
            padding: 1rem 1.25rem 1.25rem;
        }

        .body-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 1rem; }

        .panel-label {
            font-family: var(--font-display);
            font-size: .65rem; letter-spacing: .12em;
            color: var(--fog); text-transform: uppercase;
            margin-bottom: .5rem;
        }

        /* ── PARAMS TABLE ── */
        .params-table { width: 100%; border-collapse: collapse; font-size: .78rem; }
        .params-table th {
            text-align: left; padding: .4rem .6rem;
            color: var(--fog);
            border-bottom: 1px solid var(--cinder);
            font-weight: 500;
        }
        .params-table td {
            padding: .5rem .6rem;
            border-bottom: 1px solid rgba(255,255,255,.04);
            vertical-align: top;
        }
        .params-table tr:last-child td { border-bottom: none; }
        .param-name  { font-family: var(--font-mono); color: var(--fire-amber); }
        .param-in    { font-family: var(--font-mono); font-size: .68rem; color: var(--fog); }
        .param-type  { font-family: var(--font-mono); font-size: .72rem; color: #3498DB; }
        .required-tag {
            font-size: .6rem; background: rgba(255,59,31,.2); color: var(--fire-red);
            border: 1px solid rgba(255,59,31,.35); padding: .05rem .35rem; border-radius: 3px;
            margin-left: .4rem;
        }

        /* ── TRY-IT PANEL ── */
        .try-panel {
            background: rgba(28,28,30,.8);
            border: 1px solid var(--cinder);
            border-radius: 4px;
            padding: 1rem;
        }

        .param-input-row { margin-bottom: .6rem; }
        .param-input-label {
            display: flex; align-items: center; gap: .4rem;
            font-family: var(--font-mono); font-size: .72rem;
            color: var(--fog); margin-bottom: .3rem;
        }

        .param-input-label .in-badge {
            font-size: .6rem; padding: .05rem .3rem;
            border-radius: 3px; background: var(--cinder);
        }

        .param-field {
            width: 100%;
            background: var(--cinder);
            border: 1px solid var(--steel);
            border-radius: 4px;
            padding: .45rem .65rem;
            color: var(--white-smoke);
            font-family: var(--font-mono);
            font-size: .78rem;
            transition: border-color .15s;
            outline: none;
        }
        .param-field:focus { border-color: var(--fire-orange); }
        .param-field::placeholder { color: var(--steel); }

        .body-editor {
            width: 100%; min-height: 80px;
            background: var(--cinder); border: 1px solid var(--steel);
            border-radius: 4px; padding: .5rem .65rem;
            color: var(--white-smoke); font-family: var(--font-mono); font-size: .75rem;
            resize: vertical; outline: none; transition: border-color .15s;
        }
        .body-editor:focus { border-color: var(--fire-orange); }

        .exec-btn {
            margin-top: .75rem;
            display: inline-flex; align-items: center; gap: .5rem;
            background: var(--fire-red);
            color: #fff;
            font-family: var(--font-display);
            font-size: .85rem; font-weight: 600;
            letter-spacing: .06em;
            padding: .5rem 1.25rem;
            border: none; border-radius: 4px;
            cursor: pointer;
            transition: background .15s, transform .1s;
        }
        .exec-btn:hover  { background: var(--fire-orange); }
        .exec-btn:active { transform: scale(.97); }

        /* ── RESPONSE PANEL ── */
        .response-box {
            display: none;
            margin-top: .75rem;
            background: var(--smoke);
            border: 1px solid var(--cinder);
            border-radius: 4px;
            overflow: hidden;
        }

        .response-bar {
            display: flex; align-items: center; gap: .6rem;
            padding: .4rem .75rem;
            background: rgba(255,255,255,.04);
            font-family: var(--font-mono); font-size: .72rem;
        }

        .status-code {
            padding: .1rem .45rem; border-radius: 3px;
            font-weight: 600;
        }
        .status-2xx { background: rgba(46,204,113,.2); color: var(--success); }
        .status-4xx { background: rgba(255,59,31,.2);  color: var(--fire-red); }
        .status-5xx { background: rgba(231,76,60,.2);  color: #e74c3c; }

        .response-time { color: var(--fog); margin-left: auto; }

        .response-body {
            padding: .75rem;
            font-family: var(--font-mono); font-size: .75rem;
            color: #9CDCFE;
            white-space: pre-wrap; word-break: break-all;
            max-height: 260px; overflow-y: auto;
        }

        /* ── LOADING SPINNER ── */
        .spinner {
            display: none;
            width: 14px; height: 14px;
            border: 2px solid rgba(255,255,255,.25);
            border-top-color: #fff;
            border-radius: 50%;
            animation: spin .6s linear infinite;
        }
        @keyframes spin { to { transform: rotate(360deg); } }

        /* ── SCROLLBAR ── */
        ::-webkit-scrollbar { width: 5px; height: 5px; }
        ::-webkit-scrollbar-track { background: transparent; }
        ::-webkit-scrollbar-thumb { background: var(--cinder); border-radius: 4px; }

        /* ── EMPTY / LOADING STATE ── */
        .loader {
            padding: 3rem 2rem; text-align: center;
            color: var(--fog); font-size: .85rem;
        }
        .loader-flame {
            font-size: 2.5rem; margin-bottom: 1rem;
            animation: flicker 1.2s ease-in-out infinite;
        }
        @keyframes flicker { 50% { opacity: .5; transform: scale(.96); } }

        /* ── RESPONSE SCHEMAS ── */
        .schema-block {
            background: rgba(28,28,30,.9);
            border-radius: 4px;
            padding: .75rem;
            font-family: var(--font-mono); font-size: .73rem;
            color: #9CDCFE;
            white-space: pre;
            overflow-x: auto;
            margin-top: .5rem;
        }

        .response-codes { margin-top: .5rem; display: flex; flex-wrap: wrap; gap: .4rem; }
        .rcode {
            display: flex; align-items: center; gap: .35rem;
            font-family: var(--font-mono); font-size: .72rem;
            padding: .2rem .55rem; border-radius: 4px;
        }
        .rcode-2xx { background: rgba(46,204,113,.1);  color: var(--success);  border: 1px solid rgba(46,204,113,.3); }
        .rcode-4xx { background: rgba(255,59,31,.1);   color: var(--fire-red); border: 1px solid rgba(255,59,31,.3); }
        .rcode-5xx { background: rgba(231,76,60,.1);   color: #e74c3c;         border: 1px solid rgba(231,76,60,.3); }

        /* ── DIVIDER ── */
        .divider { height: 1px; background: var(--cinder); margin: 1.5rem 0; }
    </style>
</head>
<body>

<header>
    <div class=""logo"">
        <div class=""logo-icon"">🔥</div>
        <span class=""logo-text"">FIRE<span>CMD</span></span>
    </div>
    <span style=""color:var(--fog);font-size:.8rem;margin-left:.5rem;"">// API Reference</span>
    <div class=""header-badge""><span class=""status-dot""></span>OPERATIVO</div>
</header>

<div class=""layout"">
    <aside id=""sidebar"">
        <div class=""sidebar-section"">
            <div class=""sidebar-title"">Endpoints</div>
            <div id=""sidebar-links"">
                <div class=""loader"" style=""padding:1rem 1.5rem;"">Cargando...</div>
            </div>
        </div>
    </aside>

    <main id=""main"">
        <div class=""loader"" id=""global-loader"">
            <div class=""loader-flame"">🔥</div>
            Conectando con el cuartel central...
        </div>
        <div id=""content"" style=""display:none"">
            <h1 class=""page-title"">FireCommand <em>API</em></h1>
            <p class=""page-desc"" id=""api-desc"">Sistema de gestión de bomberos — documentación interactiva.</p>
            <div id=""endpoints-container""></div>
        </div>
    </main>
</div>

<script>
(function () {
    /* ─── colour helpers ─── */
    const METHOD_ICONS = { GET:'🔍', POST:'➕', PUT:'✏️', PATCH:'🔧', DELETE:'🗑️' };
    const TAG_ICONS = {};

    function methodClass(m) { return 'method-' + m.toUpperCase(); }

    function statusClass(code) {
        if (code >= 200 && code < 300) return 'status-2xx';
        if (code >= 400 && code < 500) return 'status-4xx';
        return 'status-5xx';
    }

    function rcodeClass(code) {
        const n = parseInt(code);
        if (n >= 200 && n < 300) return 'rcode-2xx';
        if (n >= 400 && n < 500) return 'rcode-4xx';
        return 'rcode-5xx';
    }

    function escapeHtml(s) {
        return String(s)
            .replace(/&/g,'&amp;').replace(/</g,'&lt;')
            .replace(/>/g,'&gt;').replace(/'/g,'&#39;');
    }

    /* ─── schema → pretty JSON sketch ─── */
    function schemaToExample(schema, defs, depth) {
        if (!schema || depth > 3) return 'null';
        if (schema['$ref']) {
            const name = schema['$ref'].split('/').pop();
            const def = defs && defs[name];
            return def ? schemaToExample(def, defs, depth + 1) : '{}';
        }
        if (schema.type === 'object' || schema.properties) {
            const props = schema.properties || {};
            const lines = Object.entries(props).map(([k,v]) =>
                '  ' + JSON.stringify(k) + ': ' + schemaToExample(v, defs, depth + 1)
            );
            return '{\n' + lines.join(',\n') + '\n}';
        }
        if (schema.type === 'array') {
            const item = schemaToExample(schema.items || {}, defs, depth + 1);
            return '[ ' + item + ' ]';
        }
        const map = { integer:'0', number:'0.0', boolean:'true', string:'""' };
        return map[schema.type] || 'null';
    }

    /* ─── build parameter input rows ─── */
    function buildParamInputs(params) {
        if (!params || !params.length) return '';
        return params.map((p, i) => `
            <div class=""param-input-row"">
                <div class=""param-input-label"">
                    <span>${escapeHtml(p.name)}</span>
                    <span class=""in-badge"">${escapeHtml(p.in)}</span>
                    ${p.required ? '<span class=""required-tag"">required</span>' : ''}
                </div>
                <input class=""param-field""
                    data-param=""${escapeHtml(p.name)}""
                    data-in=""${escapeHtml(p.in)}""
                    placeholder=""${escapeHtml(p.schema?.type || 'string')}""
                    type=""text"">
            </div>`).join('');
    }

    /* ─── build response codes ─── */
    function buildResponseCodes(responses) {
        if (!responses) return '';
        return Object.entries(responses).map(([code, resp]) => {
            const desc = resp.description || '';
            return `<span class=""rcode ${rcodeClass(code)}""><strong>${escapeHtml(code)}</strong> ${escapeHtml(desc)}</span>`;
        }).join('');
    }

    /* ─── render an endpoint card ─── */
    function renderCard(method, path, op, defs, cardId) {
        const M = method.toUpperCase();
        const params = op.parameters || [];
        const hasBody = op.requestBody;
        const summary = op.summary || op.operationId || '';
        const desc = op.description || '';
        const respCodes = buildResponseCodes(op.responses);

        let bodySchema = '';
        if (hasBody) {
            const content = op.requestBody.content || {};
            const mediaType = content['application/json'] || Object.values(content)[0] || {};
            const ex = schemaToExample(mediaType.schema || {}, defs, 0);
            bodySchema = `
                <div class=""param-input-row"">
                    <div class=""param-input-label"">Request Body (JSON)</div>
                    <textarea class=""body-editor"" data-body=""1"">${escapeHtml(ex)}</textarea>
                </div>`;
        }

        return `
        <div class=""endpoint-card"" id=""card-${escapeHtml(cardId)}"">
            <div class=""endpoint-header"" onclick=""toggleCard('${escapeHtml(cardId)}')"">
                <span class=""method-badge ${methodClass(M)}"">${M}</span>
                <span class=""endpoint-path"">${escapeHtml(path)}</span>
                <span class=""endpoint-summary"">${escapeHtml(summary)}</span>
                <span class=""chevron"">▼</span>
            </div>
            <div class=""endpoint-body"">
                <div class=""endpoint-body-inner"">
                ${desc ? `<p style=""color:var(--fog);font-size:.82rem;margin-bottom:1rem;"">${escapeHtml(desc)}</p>` : ''}

                <div class=""body-grid"">
                    <div>
                        ${params.length ? `
                        <div class=""panel-label"">Parámetros</div>
                        <table class=""params-table"">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Ubicación</th>
                                    <th>Tipo</th>
                                    <th>Descripción</th>
                                </tr>
                            </thead>
                            <tbody>
                            ${params.map(p => `
                                <tr>
                                    <td class=""param-name"">${escapeHtml(p.name)}${p.required ? `<span class=""required-tag"">req</span>` : ''}</td>
                                    <td class=""param-in"">${escapeHtml(p.in)}</td>
                                    <td class=""param-type"">${escapeHtml(p.schema?.type || '')}</td>
                                    <td style=""color:var(--fog)"">${escapeHtml(p.description || '')}</td>
                                </tr>`).join('')}
                            </tbody>
                        </table>` : ''}

                        ${respCodes ? `
                        <div class=""panel-label"" style=""margin-top:1rem;"">Respuestas</div>
                        <div class=""response-codes"">${respCodes}</div>` : ''}
                    </div>

                    <div>
                        <div class=""panel-label"">Probar</div>
                        <div class=""try-panel"">
                            ${buildParamInputs(params)}
                            ${bodySchema}
                            <button class=""exec-btn"" onclick=""executeRequest('${escapeHtml(cardId)}','${M}','${escapeHtml(path)}')"">
                                <span class=""spinner"" id=""spin-${escapeHtml(cardId)}""></span>
                                🚒 Ejecutar
                            </button>
                        </div>

                        <div class=""response-box"" id=""resp-${escapeHtml(cardId)}"">
                            <div class=""response-bar"">
                                <span class=""status-code"" id=""rcode-${escapeHtml(cardId)}""></span>
                                <span id=""rtype-${escapeHtml(cardId)}"" style=""color:var(--fog);font-size:.7rem;""></span>
                                <span class=""response-time"" id=""rtime-${escapeHtml(cardId)}""></span>
                            </div>
                            <pre class=""response-body"" id=""rbody-${escapeHtml(cardId)}""></pre>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>`;
    }

    /* ─── execute request ─── */
    window.executeRequest = async function (cardId, method, pathTemplate) {
        const card   = document.getElementById('card-' + cardId);
        const inputs = card.querySelectorAll('.param-field');
        const bodyEl = card.querySelector('[data-body]');
        const spin   = document.getElementById('spin-' + cardId);
        const respBox = document.getElementById('resp-' + cardId);
        const rcodeEl = document.getElementById('rcode-' + cardId);
        const rtimeEl = document.getElementById('rtime-' + cardId);
        const rbodyEl = document.getElementById('rbody-' + cardId);
        const rtypeEl = document.getElementById('rtype-' + cardId);

        let url = pathTemplate;
        const queryParts = [];
        const headers = { 'Accept': 'application/json' };
        let body;

        inputs.forEach(inp => {
            const val = inp.value.trim();
            if (!val) return;
            const name = inp.dataset.param;
            const loc  = inp.dataset.in;
            if (loc === 'path') url = url.replace('{' + name + '}', encodeURIComponent(val));
            else if (loc === 'query') queryParts.push(encodeURIComponent(name) + '=' + encodeURIComponent(val));
            else if (loc === 'header') headers[name] = val;
        });

        if (queryParts.length) url += '?' + queryParts.join('&');

        if (bodyEl && bodyEl.value.trim()) {
            try {
                body = bodyEl.value.trim();
                headers['Content-Type'] = 'application/json';
            } catch(_) {}
        }

        spin.style.display = 'inline-block';
        respBox.style.display = 'none';
        const t0 = Date.now();

        try {
            const opts = { method, headers };
            if (body) opts.body = body;
            const res = await fetch(url, opts);
            const elapsed = Date.now() - t0;
            const ct = res.headers.get('content-type') || '';
            let text;
            if (ct.includes('json')) {
                const json = await res.json();
                text = JSON.stringify(json, null, 2);
            } else {
                text = await res.text();
            }

            rcodeEl.textContent = res.status + ' ' + res.statusText;
            rcodeEl.className = 'status-code ' + (res.ok ? 'status-2xx' : res.status >= 400 && res.status < 500 ? 'status-4xx' : 'status-5xx');
            rtimeEl.textContent = elapsed + ' ms';
            rtypeEl.textContent = ct;
            rbodyEl.textContent = text;
        } catch(err) {
            rcodeEl.textContent = 'ERROR';
            rcodeEl.className = 'status-code status-4xx';
            rtimeEl.textContent = '';
            rtypeEl.textContent = '';
            rbodyEl.textContent = String(err);
        }

        spin.style.display = 'none';
        respBox.style.display = 'block';
    };

    /* ─── toggle card ─── */
    window.toggleCard = function(id) {
        const card = document.getElementById('card-' + id);
        card.classList.toggle('open');
        document.querySelectorAll('.sidebar-item').forEach(el => {
            el.classList.toggle('active', el.dataset.card === id && card.classList.contains('open'));
        });
    };

    /* ─── scroll to ─── */
    window.scrollToCard = function(id) {
        const card = document.getElementById('card-' + id);
        if (!card) return;
        card.scrollIntoView({ behavior: 'smooth', block: 'start' });
        if (!card.classList.contains('open')) toggleCard(id);
    };

    /* ─── MAIN: fetch & render ─── */
    fetch('/openapi/v1.json')
        .then(r => r.json())
        .then(api => {
            document.getElementById('global-loader').style.display = 'none';
            document.getElementById('content').style.display = 'block';

            const desc = api.info?.description || api.info?.title || 'Sistema de gestión integral para brigadas de bomberos.';
            document.getElementById('api-desc').textContent = desc;

            const defs = api.components?.schemas || api.definitions || {};
            const paths = api.paths || {};

            /* group by tag */
            const groups = {};
            Object.entries(paths).forEach(([path, methods]) => {
                Object.entries(methods).forEach(([method, op]) => {
                    if (typeof op !== 'object') return;
                    const tags = (op.tags && op.tags.length) ? op.tags : ['General'];
                    tags.forEach(tag => {
                        if (!groups[tag]) groups[tag] = [];
                        groups[tag].push({ method, path, op });
                    });
                });
            });

            const container = document.getElementById('endpoints-container');
            const sidebarLinks = document.getElementById('sidebar-links');
            sidebarLinks.innerHTML = '';

            if (!Object.keys(groups).length) {
                container.innerHTML = '<p style=""color:var(--fog)"">No se encontraron rutas en el documento OpenAPI.</p>';
                return;
            }

            /* create two stable columns */
            container.innerHTML = '<div id=""col-left""></div><div id=""col-right""></div>';
            const colLeft  = document.getElementById('col-left');
            const colRight = document.getElementById('col-right');

            let cardIndex = 0;
            let groupIndex = 0;
            Object.entries(groups).forEach(([tag, ops]) => {
                /* sidebar section */
                const sTitle = document.createElement('div');
                sTitle.className = 'sidebar-title';
                sTitle.style.marginTop = '.5rem';
                sTitle.textContent = tag;
                sidebarLinks.appendChild(sTitle);

                /* content section */
                const section = document.createElement('div');
                section.className = 'tag-group';
                section.style.marginBottom = '1.5rem';
                section.innerHTML = `
                    <div class=""tag-header"">
                        <span class=""tag-icon"">${TAG_ICONS[tag] || '📡'}</span>
                        <span class=""tag-name"">${escapeHtml(tag)}</span>
                        <span class=""tag-count"">${ops.length} endpoints</span>
                    </div>`;

                ops.forEach(({ method, path, op }) => {
                    const cardId = 'ep' + (cardIndex++);
                    section.innerHTML += renderCard(method, path, op, defs, cardId);

                    /* sidebar link */
                    const link = document.createElement('div');
                    link.className = 'sidebar-item';
                    link.dataset.card = cardId;
                    const M = method.toUpperCase();
                    link.innerHTML = `<span class=""method-pill ${methodClass(M)}"">${M}</span> ${escapeHtml(path)}`;
                    link.onclick = () => scrollToCard(cardId);
                    sidebarLinks.appendChild(link);
                });

                /* distribute groups alternately between columns */
                (groupIndex % 2 === 0 ? colLeft : colRight).appendChild(section);
                groupIndex++;
            });
        })
        .catch(err => {
            document.getElementById('global-loader').innerHTML =
                `<div class=""loader-flame"">⚠️</div>Error cargando OpenAPI: ${escapeHtml(String(err))}`;
        });
})();
</script>
</body>
</html>";
            return Content(html, "text/html");
        }
    }
}